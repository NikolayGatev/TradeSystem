using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Models.Enums;
using TradeSystem.Core.Models.FinacialInstrument;
using TradeSystem.Core.Models.Orders;
using TradeSystem.Core.Models.Trades;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;
using static TradeSystem.Common.ExceptionMessages;
using static TradeSystem.Common.GeneralApplicationConstants;

namespace TradeSystem.Core.Services
{
    public class TradeService : ITradeService
    {
        private readonly IDeletableEntityRepository<Order> orderRepozitory;
        private readonly IDeletableEntityRepository<Trade> tradeRepozitory;
        private readonly IDeletableEntityRepository<TradeOrder> tradeOrderRepozitory;
        private readonly IOrderService orderService;
        private readonly IClientService clientService;
        private readonly IEmployeeService employeeService;

        public TradeService(
                   IDeletableEntityRepository<Employee> employeeRepozitory
                   , IDeletableEntityRepository<ApplicationUser> aplicationUserRepozitory
                   , IDeletableEntityRepository<Client> clientRepozitory
                   , IDeletableEntityRepository<ClientFinancialInstrument> clientFinancialInstrumentRepozitory
                   , IRepository<Country> countryRepozitory
                   , IRepository<DataOfCorporateveClient> dataCorporativeClientRepozitory
                   , IRepository<DataOfIndividualClient> dataIndividualClientRepozitory
                   , IRepository<Division> divisionRepozitory
                   , IDeletableEntityRepository<FinancialInstrument> finInstrRepozitory
                   , IRepository<IdentityDocument> identityDocRepozitory
                   , IDeletableEntityRepository<Order> orderRepozitory
                   , IDeletableEntityRepository<Town> townRepozitory
                   , IDeletableEntityRepository<Trade> tradeRepozitory
                   , IDeletableEntityRepository<TradeOrder> tradeOrderRepozitory
                   , IOrderService orderService
                   , IClientService clientService
                    , IEmployeeService employeeService)
        {
            this.orderRepozitory = orderRepozitory;
            this.tradeRepozitory = tradeRepozitory;
            this.tradeOrderRepozitory = tradeOrderRepozitory;
            this.orderService = orderService;
            this.clientService = clientService;
            this.employeeService = employeeService;
        }

        public async Task<TradeQueryServiceModel> AllAsyn(
            string userId
            , string? ClientAccountId = null
            , bool? IsBid = null
            , string? ISIN = null
            , string? searchTerm = null
            , TradeSorting sorting = TradeSorting.Newest
            , int currentPage = 1
            , int ordersPerPage = 1)
        {
                var clientId = await clientService.GetClientIdByUserIdAsync(userId);

                if (clientId == null
                    && await employeeService.ExistsByUserIdAsync(userId) == false)
                {
                    throw new UnauthoriseActionException(MessageUnauthoriseActionException);
                }

                var tradesToShow = tradeRepozitory.AllAsNoTracking();

                if (ISIN != null)
                {
                tradesToShow = tradesToShow
                        .Where(o => o.FinancialInstrument.ISIN == ISIN);
                }

                if (ClientAccountId != null
                    && Guid.TryParse(ClientAccountId, out Guid id)
                    && (await clientService.ExistClientByIdAsync(id)))
                {
                tradesToShow = tradesToShow
                        .Where(t => t.TradeOrders.Any(to => to.Order.ClientId == id));

                    if (IsBid != null)
                    {
                        tradesToShow = tradesToShow
                            .Where(t => t.TradeOrders.Any(to => to.Order.ClientId == id && to.Order.IsBid == IsBid));
                    }

                }

                if (searchTerm != null)
                {
                    string normalizedSearcTerm = searchTerm.ToLower();

                tradesToShow = tradesToShow
                    .Where(o => o.Price.ToString().ToLower().Contains(normalizedSearcTerm)
                        || o.FinancialInstrument.Name.ToLower().Contains(normalizedSearcTerm)
                        || o.CreatedOn.ToString().ToLower().Contains(normalizedSearcTerm));
                }

                tradesToShow = sorting switch
                {
                    TradeSorting.FinancialInstrument => tradesToShow
                        .OrderBy(o => o.FinancialInstrument.Name)
                        .ThenByDescending(o => o.CreatedOn),
                    TradeSorting.Turnover => tradesToShow
                        .OrderByDescending(o => o.Price * o.Volume)
                        .ThenByDescending(f => f.CreatedOn),
                    _ => tradesToShow
                        .OrderByDescending(o => o.CreatedOn),
                };

                if (clientId != null)
                {
                tradesToShow = tradesToShow.Where(t => t.TradeOrders.Any(to => to.Order.ClientId == clientId));
                }

                var trades = await tradesToShow
                    .Skip((currentPage - 1) * ordersPerPage)
                    .Take(ordersPerPage)
                    .Select(o => new TradeDetailsServiceModel()
                    {
                        Id = o.Id,
                        FinancialInstrumentName = o.FinancialInstrument.Name,
                        CreatedOn = o.CreatedOn.ToString(DateFormat),
                        Price = o.Price,
                        Volume = o.Volume,
                        BidAsk = o.TradeOrders.Any(to => to.Order.IsBid && to.Order.ClientId == clientId) && o.TradeOrders.Any(to => to.Order.IsBid == false && to.Order.ClientId == clientId)
                                    ? "Cross"
                                    :(o.TradeOrders.Any(to => to.Order.IsBid && to.Order.ClientId == clientId)
                                        ? "Buy"
                                        : "Sell"),
                        Turnover = o.Price * o.Volume,
                        FinancialInstrumentId = o.FinancialInstrumentId,
                    })
                    .ToListAsync();

                int totalTrades = clientId != null
                ? await tradesToShow.Where(o => o.TradeOrders.Any(to => to.Order.ClientId == clientId)).CountAsync()
                : await tradesToShow.CountAsync();

                return new TradeQueryServiceModel()
                {
                    Trades = trades,
                    TotalTradesCount = totalTrades,
                };
        }

        public async Task DeleteAsync(Guid tradeId, string userId)
        {
            var clientId = await clientService.GetClientIdByUserIdAsync(userId);
            var isCounterparty = await UsarIdIsCounterpartyByTrade(clientId ?? new Guid(), tradeId);
            var isEmployee = await employeeService.ExistsByUserIdAsync(userId);

            if ((await ExistTradeByIdAsync(tradeId) == false)
                || (isCounterparty == false && isEmployee == false))
            {
                throw new UnauthoriseActionException(MessageUnauthoriseActionException);
            }

            var trade = await GetTradeByIdAcync(tradeId);
            if(trade != null)
            {
                tradeRepozitory.Delete(trade);
            }
        }

        public async Task<bool> ExistTradeByIdAsync(Guid tradeId)
        {
           var trade = await GetTradeByIdAcync(tradeId);

            if (trade != null)
            {
                return await tradeRepozitory.AllAsNoTracking().ContainsAsync(trade);
            }
            return false;
        }

        public async Task<IEnumerable<OrdersOfTradeServiceModel>> GetOrdersOfTradeByIdAsync(Guid tradeId)
        {
            var result = await tradeOrderRepozitory.AllAsNoTrackingWithDeleted()
                .Where(o => o.OrderId == tradeId)
                .Select(o => new OrdersOfTradeServiceModel()
                {
                    OrderId = o.Order.Id,
                    CurrentExecuted = o.Trade.Volume,
                    InitialVolume = o.Order.InitialVolume,
                    IsBid = o.Order.IsBid
                            ? "Bid"
                            : "Ask",
                    ClientId = o.Order.ClientId,
                })
                .OrderBy(t => t.IsBid)
                .ToListAsync();

            return result;
        }

        public async Task<TradeDetailsServiceModel> GetTradeDetailsByIdAsync(Guid tradeId, string userId)
        {
            var clientId = await clientService.GetClientIdByUserIdAsync(userId);            
            var isCounterparty = await UsarIdIsCounterpartyByTrade(clientId ?? new Guid(), tradeId);
            var isEmployee = await employeeService.ExistsByUserIdAsync(userId);

            if ((await ExistTradeByIdAsync(tradeId) == false )
                || (isCounterparty == false && isEmployee == false) )
            {
                throw new UnauthoriseActionException(MessageUnauthoriseActionException);
            }

            TradeDetailsServiceModel result = await tradeRepozitory.AllAsNoTracking()
                .Where(t => t.Id == tradeId)
                .Select(t => new TradeDetailsServiceModel()
                {
                    Id = t.Id,
                    Volume = t.Volume,
                    Price = t.Price,
                    Turnover = t.Price * t.Volume,
                    CreatedOn = t.CreatedOn.ToString(DateFormat),
                    FinancialInstrumentId = t.FinancialInstrumentId,
                    FinancialInstrumentName = t.FinancialInstrument.Name, 
                    BidAsk = isCounterparty
                               ? (t.TradeOrders.Any(to => to.Order.IsBid && to.Order.ClientId == clientId) && t.TradeOrders.Any(to => to.Order.IsBid == false && to.Order.ClientId == clientId)
                                    ? "Cross"
                                    : (t.TradeOrders.Any(to => to.Order.IsBid && to.Order.ClientId == clientId)
                                        ? "Buy"
                                        : "Sell"))
                                :null,
                })
                .FirstAsync();

            result.Orders = await GetOrdersOfTradeByIdAsync(tradeId);

            if(isCounterparty)
            {
                result.Orders = result.Orders.Where(o => o.ClientId == clientId);
            }

            return result;
        }

        public async Task<Trade?> GetTradeByIdAcync(Guid tradeId)
        {
            return await tradeRepozitory.AllAsNoTracking()
                .Where(t => t.Id == tradeId)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> UsarIdIsCounterpartyByTrade(Guid clientId, Guid tradeId)
        {
            var result = await tradeRepozitory.AllAsNoTracking().Where(t => t.Id == tradeId)
                .SelectMany(t => t.TradeOrders.Where(to => to.Order.ClientId == clientId))
                .FirstOrDefaultAsync();

            return result != null
                ? true
                : false;
        }

        public async Task<Trade?> GetTradeByIdAsync(Guid tradeId)
        {
            var result = await tradeRepozitory.All()
                .Where(t => t.Id == tradeId)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<RealTimeTradeServiceModel>> RealTimeTrdeAcync()
        {
            var tradesToShow = await tradeRepozitory.AllAsNoTracking()
                .OrderByDescending(t => t.CreatedOn)
                .Select(t => new RealTimeTradeServiceModel()
                {
                    ISIN = t.FinancialInstrument.ISIN,
                    Name = t.FinancialInstrument.Name,
                    FinancialInstrumentId = t.FinancialInstrument.Id,
                    TimeOfTrade = t.CreatedOn.ToString(DateTimeFormat),
                    Price = t.Price,
                    Volume = t.Volume,
                })
                .ToListAsync();
            var result = tradesToShow
                                .GroupBy(t => t.FinancialInstrumentId)
                                .Select(t => t.First());
                

            return result;
        }
    }    
}
