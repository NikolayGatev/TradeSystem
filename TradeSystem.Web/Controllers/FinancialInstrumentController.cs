using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Models.FinacialInstrument;
using TradeSystem.Web.Attributes;

namespace TradeSystem.Web.Controllers
{
    public class FinancialInstrumentController : BaseController
    {
        private readonly IFinancialInstrumentService finInsinstrumentService;
        private readonly IClientService clientService;
        private readonly IEmployeeService employeeService;
        private readonly ILogger<ClientController> logger;

        public FinancialInstrumentController(
            IFinancialInstrumentService finInsinstrumentService
            , IClientService clientService
            , IEmployeeService employeeService
            , ILogger<ClientController> logger)
        {
            this.finInsinstrumentService = finInsinstrumentService;
            this.clientService = clientService;
            this.employeeService = employeeService;
            this.logger = logger;
        }

        [HttpGet]
        [MustBeEmployee]

        public async Task<IActionResult> Add()
        {
            var model = new FinacialInstrumentFormModel();
            
            return View(model);
        }

        [HttpPost]
        [MustBeEmployee]

        public async Task<IActionResult> Add(FinacialInstrumentFormModel model)
        {
            if(ModelState.IsValid == false)
            {
                return View(model);
            }

            int id;

            try
            {
                id = await finInsinstrumentService.CreateAsync(model);
            }
            catch (ExistFinancialInstrumentWithThisNameOrISIN efi)
            {
                logger.LogError(efi, "FinacialInstrumentController/Add");

                return View(model);
            }
            

            return RedirectToAction(nameof(Details), new { id });
        }

        [AllowAnonymous]
        [HttpGet]

        public async Task<IActionResult> Details(int id)
        {
            var model = new FinInstrumentDetailsServiceModel();

            try
            {
                model = await finInsinstrumentService.GetFinInstrumentDetailsByIdAsync(id);
            }
            catch (Exception ms)
            {
                logger.LogError(ms, "FinacialInstrumentController/Add");

                RedirectToAction(nameof(Index), "Home");
            }

            return View(model);
        }

        [HttpGet]
        [MustBeEmployee]

        public async Task<IActionResult> Edit(int id)
        {                      

            var model = new FinacialInstrumentFormModel();

            try
            {
                model = await finInsinstrumentService.GetEditAsync(id);
            }
            catch (Exception ms)
            {
                logger.LogError(ms, "FinacialInstrumentController/Edit");

                RedirectToAction(nameof(Index), "Home");
            }
            
            return View(model);
        }

        [HttpPost]
        [MustBeEmployee]

        public async Task<IActionResult> Edit(int id, FinacialInstrumentFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            try
            {
                await finInsinstrumentService.EditAsyn(id, model);
            }
            catch (Exception ms)
            {
                logger.LogError(ms, "FinacialInstrumentController/Edit");

                RedirectToAction(nameof(Index), "Home");
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        [MustBeEmployee]

        public async Task<IActionResult> Delete(int id)
        {
            var model = new FinInstrumentDetailsServiceModel();

            try
            {
                model = await finInsinstrumentService.GetFinInstrumentDetailsByIdAsync(id);
            }
            catch (Exception ms)
            {
                logger.LogError(ms, "FinacialInstrumentController/Delete");

                RedirectToAction(nameof(Index), "Home");
            }

            return View(model);
        }

        [HttpPost]
        [MustBeEmployee]

        public async Task<IActionResult> Delete(FinInstrumentDetailsServiceModel model)
        {
            try
            {
                await finInsinstrumentService.DeleteAsync(model.Id);
            }
            catch (Exception ms)
            {
                logger.LogError(ms, "FinacialInstrumentController/Delete");

                RedirectToAction(nameof(Index), "Home");
            }

            return RedirectToAction(nameof(All));
        }

        [AllowAnonymous]
        [HttpGet]

        public async Task<IActionResult> All([FromQuery] AllFinancialInstrumentsQueryModel query)
        {
            var model = await finInsinstrumentService.AllAsyn(
                query.ISIN
                , query.SearchTerm
                , query.Sorting
                , query.CurrentPage
                , query.FinInstrumentsPerPage);

            query.TotalFinInstrumentsCount = model.TotalFinInstrumentCount;
            query.FinInstruments = model.FinancialInstruments;
            query.ISINs = await finInsinstrumentService.AllISINsAsync();

            return View(query);
        }
    }
}
