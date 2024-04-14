using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Extensions;
using TradeSystem.Core.Models.FinacialInstrument;
using TradeSystem.Web.Attributes;

namespace TradeSystem.Web.Controllers
{
    public class FinancialInstrumentController : BaseController
    {
        private readonly IFinancialInstrumentService finInsinstrumentService;
        private readonly IClientService clientService;
        private readonly IEmployeeService employeeService;
        private readonly IOrderService orderService;
        private readonly ILogger<ClientController> logger;

        public FinancialInstrumentController(
            IFinancialInstrumentService finInsinstrumentService
            , IClientService clientService
            , IEmployeeService employeeService
            ,IOrderService orderService
            , ILogger<ClientController> logger)
        {
            this.finInsinstrumentService = finInsinstrumentService;
            this.clientService = clientService;
            this.employeeService = employeeService;
            this.orderService = orderService;
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

            try
            {
                int id = await finInsinstrumentService.CreateAsync(model);

                return RedirectToAction(nameof(Details), new { id, financialInstrument = model.GetNameAndIsin() });
            }
            catch (NonExistFinancialInstrumentWithThisNameOrISIN efi)
            {
                logger.LogError(efi, "FinacialInstrumentController/Add");

                return View(model);
            }            
        }

        [AllowAnonymous]
        [HttpGet]

        public async Task<IActionResult> Details(int id, string financialInstrument)
        {
            if(await finInsinstrumentService.ExixtFinancialInstrumentAsync(id) == false)
            {
                return BadRequest();
            }

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


            if (financialInstrument != model.GetNameAndIsin())
            {
                return BadRequest();
            }

                return View(model);
        }

        [HttpGet]
        [MustBeEmployee]

        public async Task<IActionResult> Edit(int id)
        {
            if (await finInsinstrumentService.ExixtFinancialInstrumentAsync(id) == false)
            {
                return BadRequest();
            }

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
            if (await finInsinstrumentService.ExixtFinancialInstrumentAsync(id) == false)
            {
                return BadRequest();
            }

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

            return RedirectToAction(nameof(Details), new { id, financialInstrument = model.GetNameAndIsin() });
        }

        [HttpGet]
        [MustBeEmployee]

        public async Task<IActionResult> Delete(int id)
        {
            if (await finInsinstrumentService.ExixtFinancialInstrumentAsync(id) == false)
            {
                return BadRequest();
            }

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
                await orderService.DeleteAllOredersByFinancialInstrumentAsync(model.Id, User.Id());
            }
            catch (UnauthoriseActionException ua)
            {
                logger.LogError(ua, "FinacialInstrumentController/Delete");

                return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception ms)
            {
                logger.LogError(ms, "FinacialInstrumentController/Delete");

                return RedirectToAction(nameof(Index), "Home");
            }

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
