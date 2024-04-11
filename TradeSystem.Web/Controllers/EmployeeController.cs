using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Models.Clients;
using TradeSystem.Core.Models.Employees;
using TradeSystem.Web.Attributes;
using static TradeSystem.Common.ErrorConstants;

namespace TradeSystem.Web.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService employeeService;
        private readonly IClientService clientService;
        private readonly IFinancialInstrumentService financialInstrumentService;
        private readonly ILogger<EmployeeController> logger;

        public EmployeeController(
            IEmployeeService employeeService
            ,IClientService clientService
            ,IFinancialInstrumentService financialInstrumentService
            ,ILogger<EmployeeController> logger)
          
        {
            this.employeeService = employeeService;
            this.clientService = clientService;
            this.financialInstrumentService = financialInstrumentService;
            this.logger = logger;
        }

        [HttpGet]
        [NotEmployee]

        public async Task<IActionResult> AddNewEmployee()
        {

            var model = new EmployeeFormModel()
            {
                Divisions = await employeeService.AllDivisionsAsync(),
            };

           return View(model);
        }

        [HttpPost]
        [NotEmployee]

        public async Task<IActionResult> AddNewEmployee(EmployeeFormModel model)
        {
            var userId = User.Id();

            if(await employeeService.DivisionExistsAsync(model.DivisionId) == false)
            {
                ModelState.AddModelError(nameof(model.DivisionId), UnknownDivision);
            }

            if(ModelState.IsValid == false)
            {
                model.Divisions = await employeeService.AllDivisionsAsync();

                return View(model);
            }
            
            var newEmployeeId = await employeeService.CreateEmployeeAsync(model, userId);

            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpGet]
        [MustBeEmployee]

        public async Task<IActionResult> EmployeeDetails(Guid? employeeId)
        {            
            Guid newId = (employeeId ?? await employeeService.GetIdOfEmployeeByUserIdAsync(User.Id())) ?? Guid.Empty;
            
            try
            {
                var model = await employeeService.DetailsOfEmployeeByIdAsync(newId);

                return View(model);
            }
            catch (NonEmployeeException nee)
            {
                logger.LogError(nee, "EmployeeController/EmployeeDetails");
                return BadRequest();
            }
        }

        [HttpGet]
        [MustBeEmployee]

        public async Task<IActionResult> AllDataOfClients([FromQuery] AllClientsDataQueryModel query)
        {
            var model = await clientService.AllClientsDataAsync(
                query.Nationality
                , query.Status
                , query.SearchTerm
                , query.TypeOfClient
                , query.LinePerPage
                , query.CurrentPage);

            query.TotalDataCount = model.TotalClientsDataCount;
            query.ClientsData = model.ClientsData;
            query.Nationalities = await employeeService.AllCountriesNameAsync();
            query.Statuses = employeeService.AllStatusesName();
            query.TypeOfClients = clientService.AllTypeOfClientsName();

            return View(query);
        }
        
        [MustBeEmployee]

        public async Task<IActionResult> Reject (string userId)
        {
            try
            {
                await employeeService.RejectClientDataAsync(User.Id(), userId);

                return RedirectToAction(nameof(AllDataOfClients));
            }
            catch (NonDataOfClientException nde)
            {
                logger.LogError(nde, "EmployeeController/Reject");
                return BadRequest();
            }
        }

        [MustBeEmployee]

        public async Task<IActionResult> Accept(string userId)
        {
            try
            {
                await employeeService.AcceptClientDataAsync(User.Id(), userId);

                return RedirectToAction(nameof(AllDataOfClients));
            }
            catch (NonDataOfClientException nde)
            {
                logger.LogError(nde, "EmployeeController/Reject");
                return BadRequest();
            }
        }

        [MustBeEmployee]
        [HttpGet]

        public async Task<IActionResult> Edit(Guid employeeId)
        {
            try
            {
                var model = await employeeService.GetEmployeeFormByIdAsync(employeeId);
                return View(model);
            }
            catch (NonEmployeeException nee)
            {
                logger.LogError(nee, "EmployeeController/Edit");
                return BadRequest();
            }
        }

        [MustBeEmployee]
        [HttpPost]

        public async Task<IActionResult> Edit(Guid employeeId, EmployeeDetailsServiceModel model)
        {
            if(await employeeService.DivisionExistsAsync(model.DivisionId) == false)
            {
                ModelState.AddModelError(nameof(model.DivisionId), UnknownDivision);
            }

            if(ModelState.IsValid == false)
            {
                model.Divisions = await employeeService.AllDivisionsAsync();

                return View(model);
            }

            try
            {
                await employeeService.EditAsync(employeeId, model);

                if(User.IsAdmin())
                {
                    return RedirectToAction("AllEmployees", "Employee", new { area = "Administrator" });
                }

                return RedirectToAction(nameof(EmployeeDetails), new { employeeId });
            }
            catch (NonEmployeeException nee)
            {
                logger.LogError(nee, "EmployeeController/Edit");
                return BadRequest();
            }
        }

        [MustBeEmployee]
        [HttpGet]

        public async Task<IActionResult> Delete(Guid employeeId)
        {
            try
            {
                var model = await employeeService.DetailsOfEmployeeByIdAsync(employeeId);
                return View(model);
            }
            catch (NonEmployeeException nee)
            {
                logger.LogError(nee, "EmployeeController/Edit");
                return BadRequest();
            }
        }

        [MustBeEmployee]
        [HttpPost]

        public async Task<IActionResult> Delete(EmployeeDetailsServiceModel model, Guid employeeId)
        {
            try
            {
                await employeeService.SoftDeleteAsync(employeeId);

                return RedirectToAction(nameof(Index), "Home");
            }
            catch (NonEmployeeException nee)
            {
                logger.LogError(nee, "EmployeeController/Delete");
                return BadRequest();
            }
        }

        [MustBeEmployee]
        [HttpGet]

        public async Task<IActionResult> FundedCount()
        {
            var model = new ClientFinancialInstrumentFormModel()
            {
                Clients = await clientService.AllClientsAsync(),
                FinancialInstruments = await financialInstrumentService.AllFinancialInstrumentsAsync()
            };

            return View(model);
        }

        [MustBeEmployee]
        [HttpPost]

        public async Task<IActionResult> FundedCount (ClientFinancialInstrumentFormModel model)
        {
            if (await financialInstrumentService.ExixtFinancialInstrumentAsync(model.FinancialInstrumentId) == false)
            {
                ModelState.AddModelError(nameof(model.FinancialInstrumentId), UnknownFinancialInstrument);
            }

            if (await clientService.ExistClientByIdAsync(model.ClientId) == false)
            {
                ModelState.AddModelError(nameof(model.ClientId), UnknownClient);
            }

            if (ModelState.IsValid == false)
            {
                model.Clients = await clientService.AllClientsAsync();
                model.FinancialInstruments = await financialInstrumentService.AllFinancialInstrumentsAsync();

                return View(model);
            }

            try
            {
                await financialInstrumentService.FundedAccountWithFinancialInstruments(model.ClientId, model.FinancialInstrumentId, model.Volume);
            }
            catch(NonFinancialInstrumentException nfi)
            {
                logger.LogError(nfi, "EmployeeController/FundedCount");
                return BadRequest();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "EmployeeController/FundedCount");
                return BadRequest();
            }

            return RedirectToAction(nameof(AllDataOfClients));
        }
    }    
}
