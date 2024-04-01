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
                FinancialInstruments = await financialInstrumentService.AllFinancialInstrumentsOfClientAsync(Guid.Parse(User.Id())),
                Balance = await orderService.GetBalanceByUserIdAsync(Guid.Parse(User.Id()))
            };
            return View(model);
        }

        [HttpPost]
        [MustBeClientAccount]

        public async Task<IActionResult> Add(OrderFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                model.FinancialInstruments = await financialInstrumentService.AllFinancialInstrumentsOfClientAsync(Guid.Parse(User.Id()));
                model.Balance = await orderService.GetBalanceByUserIdAsync(Guid.Parse(User.Id()));

                return View(model);
            }

            var clientId = await clientService.GetClientIdByUserIdAsync(Guid.Parse(User.Id()));

            try
            {
                if(await orderService.NotEnoughMoneyAsync(clientId, (model.Price * model.InitialVolume)))
                {

                }
            }
            catch (Exception)
            {

                throw;
            }

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
            var model = new OrderDetailsServiceModel();

            var userId = Guid.Parse(User.Id());

            try
            {
                model = await orderService.GetOrderDetailsByIdAsync(orderId, userId);
            }
            catch (UnauthoriseActionException ua)
            {
                logger.LogError(ua, "OrderController/Details");

                RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception ms)
            {
                logger.LogError(ms, "OrderController/Details");

                RedirectToAction(nameof(Index), "Home");
            }

            return View(model);
        }

        [HttpGet]

        public async Task<IActionResult> Delete(Guid orderId)
        {
            var model = new OrderDetailsServiceModel();

            var userId = Guid.Parse(User.Id());

            try
            {
                model = await orderService.GetOrderDetailsByIdAsync(orderId, userId);
            }
            catch (UnauthoriseActionException ua)
            {
                logger.LogError(ua, "OrderController/Delete");

                RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception ms)
            {
                logger.LogError(ms, "OrderController/Delete");

                RedirectToAction(nameof(Index), "Home");
            }

            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(OrderDetailsServiceModel model)
        {
            var userId = Guid.Parse(User.Id());

            try
            {
                await orderService.DeleteAsync(model.Id, userId);
            }
            catch (UnauthoriseActionException ua)
            {
                logger.LogError(ua, "OrderController/Delete");

                RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception ms)
            {
                logger.LogError(ms, "OrderController/Delete");

                RedirectToAction(nameof(Index), "Home");
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]

        public async Task<IActionResult> All([FromQuery] AllOrdersQueryModel query)
        {
            var userId = Guid.Parse(User.Id());

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
                query.ClientAccountIds = await orderService.AllClintsIdAsync(userId);
            }
            catch (UnauthoriseActionException ua)
            {
                logger.LogError(ua, "OrderController/Delete");

                RedirectToAction(nameof(Index), "Home");
            }

            return View(query);
        }
    }
}
