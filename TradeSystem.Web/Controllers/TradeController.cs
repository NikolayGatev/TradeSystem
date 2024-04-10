using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Models.Trades;

namespace TradeSystem.Web.Controllers
{
    public class TradeController : BaseController
    {
        private readonly ITradeService tradeService;
        private readonly IOrderService orderService;
        private readonly IClientService clientService;
        private readonly ILogger<OrderController> logger;
        private readonly IFinancialInstrumentService financialInstrumentService;

        public TradeController(
            ITradeService tradeService
            , IOrderService orderService
            , IClientService clientService
            , ILogger<OrderController> logger
            , IFinancialInstrumentService financialInstrumentService)
        {
            this.tradeService = tradeService;
            this.orderService = orderService;
            this.clientService = clientService;
            this.logger = logger;
            this.financialInstrumentService = financialInstrumentService;
        }

        [HttpGet]

        public async Task<IActionResult> Details(Guid tradeId)
        {
            if(await tradeService.ExistTradeByIdAsync(tradeId) == false)
            {
                return BadRequest();
            }

            var model = new TradeDetailsServiceModel();

            var userId = User.Id();

            try
            {
                model = await tradeService.GetTradeDetailsByIdAsync(tradeId, userId);

                return View(model);
            }
            catch (UnauthoriseActionException ua)
            {
                logger.LogError(ua, "OrderController/Details");

                return RedirectToAction(nameof(Index), "Home");
            }
            catch (Exception ms)
            {
                logger.LogError(ms, "OrderController/Details");

                return RedirectToAction(nameof(Index), "Home");
            }
        }

        [HttpGet]

        public async Task<IActionResult> Delete(Guid tradeId)
        {
            if (await tradeService.ExistTradeByIdAsync(tradeId) == false)
            {
                return BadRequest();
            }

            var model = new TradeDetailsServiceModel();

            var userId = User.Id();

            try
            {
                model = await tradeService.GetTradeDetailsByIdAsync(tradeId, userId);

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

        public async Task<IActionResult> Delete(TradeDetailsServiceModel model)
        {
            if (await tradeService.ExistTradeByIdAsync(model.Id) == false)
            {
                return BadRequest();
            }

            var userId = User.Id();

            try
            {
                await tradeService.DeleteAsync(model.Id, userId);

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

        public async Task<IActionResult> All([FromQuery] AllTradesQueryModel query)
        {
            var userId = User.Id();

            try
            {
                var model = await tradeService.AllAsyn(
                userId
                , query.ClientAccountId
                , query.IsBid
                , query.ISIN
                , query.SearchTerm
                , query.Sorting
                , query.CurrentPage
                , query.TradesPerPage);

                query.TotalTradesCount = model.TotalTradesCount;
                query.Trades = model.Trades;
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

        [AllowAnonymous]

        public async Task<IActionResult> RealTimeTrade()
        {
            var model = await tradeService.RealTimeTrdeAcync();
            return View(model);
        }
    }
}

