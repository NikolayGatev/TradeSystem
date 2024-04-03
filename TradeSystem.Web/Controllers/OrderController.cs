using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Models.FinacialInstrument;
using TradeSystem.Core.Models.Orders;
using TradeSystem.Core.Services;
using TradeSystem.Data.Models;
using TradeSystem.Web.Attributes;

namespace TradeSystem.Web.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly IClientService clientService;
        private readonly ILogger<OrderController> logger;
        private readonly IFinancialInstrumentService financialInstrumentService;

        public OrderController(
           IOrderService orderService
            ,IClientService clientService
            , ILogger<OrderController> logger
            , IFinancialInstrumentService financialInstrumentService)
        {
            this.orderService = orderService;
            this.clientService = clientService;
            this.logger = logger;
            this.financialInstrumentService = financialInstrumentService;
        }

        [HttpGet]
        [MustBeClientAccount]

        public async Task<IActionResult> Add()
        
        {
            var model = new OrderFormModel()
            {
                FinancialInstruments = await financialInstrumentService.AllFinancialInstrumentsOfClientAsync(User.Id()),
                Balance = await orderService.GetBalanceByUserIdAsync(User.Id())
            };
            return View(model);
        }

        [HttpPost]
        [MustBeClientAccount]

        public async Task<IActionResult> Add(OrderFormModel model)
        {
            if (await financialInstrumentService.ExixtFinancialInstrumentAsync(model.FinancialInstrumentId) == false)
            {
                return BadRequest();
            }

            if (ModelState.IsValid == false)
            {
                model.FinancialInstruments = await financialInstrumentService.AllFinancialInstrumentsOfClientAsync(User.Id());
                model.Balance = await orderService.GetBalanceByUserIdAsync(User.Id());

                return View(model);
            }

            var clientId = await clientService.GetClientIdByUserIdAsync(User.Id());

            Guid id;

            try
            {
                id = await orderService.CreateAsync(model, clientId);
            }
            catch (NonExistFinancialInstrumentWithThisNameOrISIN efi)
            {
                logger.LogError(efi, "OrderController/Add");

                return View(model);
            }
            catch (UnauthoriseActionException ua)
            {
                logger.LogError(ua, "OrderController/Add");

                return Unauthorized();
            }


            return RedirectToAction(nameof(Details), new { orderId = id });
        }
                
        [HttpGet]

        public async Task<IActionResult> Details(Guid orderId)
        {
            if (await orderService.ExistOrderByIdAsync(orderId) == false)
            {
                return BadRequest();
            }

            var userId = User.Id();

            try
            {
               var model = await orderService.GetOrderDetailsByIdAsync(orderId, userId);
                return View(model);
            }
            catch (UnauthoriseActionException ua)
            {
                logger.LogError(ua, "OrderController/Details");

               return  RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception ms)
            {
                logger.LogError(ms, "OrderController/Details");

                return RedirectToAction(nameof(Index), "Home");
            }

        }

        [HttpGet]

        public async Task<IActionResult> Delete(Guid orderId)
        {
            if (await orderService.ExistOrderByIdAsync(orderId) == false)
            {
                return BadRequest();
            }

            var userId = User.Id();

            try
            {
                var model = await orderService.GetOrderDetailsByIdAsync(orderId, userId);
                return View(model);
            }
            catch (UnauthoriseActionException ua)
            {
                logger.LogError(ua, "OrderController/Delete");

                return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception ms)
            {
                logger.LogError(ms, "OrderController/Delete");

                return RedirectToAction(nameof(Index), "Home");
            }

        }

        [HttpPost]

        public async Task<IActionResult> Delete(OrderDetailsServiceModel model)
        {
            if (await orderService.ExistOrderByIdAsync(model.Id) == false)
            {
                return BadRequest();
            }

            var userId = User.Id();

            try
            {
                await orderService.DeleteAsync(model.Id, userId);
                return RedirectToAction(nameof(All));
            }
            catch (UnauthoriseActionException ua)
            {
                logger.LogError(ua, "OrderController/Delete");

                return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception ms)
            {
                logger.LogError(ms, "OrderController/Delete");

                return RedirectToAction(nameof(Index), "Home");
            }

        }

        [HttpGet]

        public async Task<IActionResult> All([FromQuery] AllOrdersQueryModel query)
        {
            var userId = User.Id();

            try
            {
                var model = await orderService.AllAsyn(
                userId
                , query.ClientAccountId
                , query.IsBid
                , query.IsNotActive
                , query.ISIN
                , query.SearchTerm
                , query.Sorting
                , query.CurrentPage
                , query.OrdersPerPage);

                query.TotalOrdersCount = model.TotalOrdersCount;
                query.Orders = model.Orders;
                query.ISINs = await financialInstrumentService.AllISINsAsync();
                query.ClientAccountIds = await clientService.AllClintsIdAsync(userId);

                return View(query);
            }
            catch (UnauthoriseActionException ua)
            {
                logger.LogError(ua, "OrderController/Delete");

                return RedirectToAction(nameof(Index), "Home");
            }
        }
    }
}
