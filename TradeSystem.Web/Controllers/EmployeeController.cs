using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Models.Clients;
using TradeSystem.Core.Models.Employees;
using TradeSystem.Core.Services;
using TradeSystem.Data.Models;
using TradeSystem.Web.Attributes;
using static TradeSystem.Common.ErrorConstants;

namespace TradeSystem.Web.Controllers
{
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService employeeService;
        private readonly IClientService clientService;
        private readonly ILogger<EmployeeController> logger;

        public EmployeeController(
            IEmployeeService employeeService
            ,IClientService clientService
            ,ILogger<EmployeeController> logger)
          
        {
            this.employeeService = employeeService;
            this.clientService = clientService;
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
            Guid userId = Guid.Parse(User.Id());

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

            return RedirectToAction(nameof(EmployeeDetails), new {employeeId = newEmployeeId});
        }

        [HttpGet]
        [MustBeEmployee]

        public async Task<IActionResult> EmployeeDetails(Guid? employeeId)
        {            
            Guid newId = (employeeId ?? await employeeService.GetIdOfEmployeeByUserIdAsync(Guid.Parse(User.Id()))) ?? Guid.Empty;
            
            try
            {
                var model = await employeeService.DetailsOfEmployeeByIdAsync(newId);

                return View(model);
            }
            catch (NotEmployeeException nee)
            {
                logger.LogError(nee, "EmployeeController/EmployeeDetails");
                return BadRequest();
            }
        }

        [HttpGet]
        [MustBeEmployee]

        public async Task<IActionResult> AllDataOfClients([FromQuery] AllClientsDataQueryModel query)
        {
            var model = await employeeService.AllClientsDataAsync(
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
            query.TypeOfClients = employeeService.AllTypeOfClientsName();

            return View(query);
        }
        
        [MustBeEmployee]

        public async Task<IActionResult> Reject (Guid userId)
        {
            try
            {
                await employeeService.RejectClientDataAsync(Guid.Parse(User.Id()), userId);

                return RedirectToAction(nameof(AllDataOfClients));
            }
            catch (NotDataOfClientException nde)
            {
                logger.LogError(nde, "EmployeeController/Reject");
                return BadRequest();
            }
        }

        [MustBeEmployee]

        public async Task<IActionResult> Accept(Guid userId)
        {
            try
            {
                await employeeService.AcceptClientDataAsync(Guid.Parse(User.Id()), userId);

                return RedirectToAction(nameof(AllDataOfClients));
            }
            catch (NotDataOfClientException nde)
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
            catch (NotEmployeeException nee)
            {
                logger.LogError(nee, "EmployeeController/Edit");
                return BadRequest();
            }
        }

        [MustBeEmployee]
        [HttpPost]

        public async Task<IActionResult> Edit(Guid employeeId, EmployeeFormModel model)
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

                return RedirectToAction(nameof(EmployeeDetails), new { employeeId });
            }
            catch (NotEmployeeException nee)
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
            catch (NotEmployeeException nee)
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
            catch (NotEmployeeException nee)
            {
                logger.LogError(nee, "EmployeeController/Delete");
                return BadRequest();
            }
        }
    }
}
