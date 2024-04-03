using Microsoft.EntityFrameworkCore;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Models.Employees;
using TradeSystem.Core.Models.Enums;
using TradeSystem.Core.Models.FinacialInstrument;
using TradeSystem.Core.Models.Orders;
using TradeSystem.Data.Common;
using TradeSystem.Data.Migrations;
using TradeSystem.Data.Models;
using static TradeSystem.Common.ExceptionMessages;
using static TradeSystem.Common.MessageConstants;

namespace TradeSystem.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDeletableEntityRepository<Employee> employeeRepozitory;
        private readonly IDeletableEntityRepository<ApplicationUser> aplicationUserRepozitory;
        private readonly IDeletableEntityRepository<Client> clientRepozitory;
        private readonly IDeletableEntityRepository<ClientFinancialInstrument> clientFinancialInstrumentRepozitory;
        private readonly IRepository<Country> countryRepozitory;
        private readonly IRepository<DataOfCorporateveClient> dataCorporativeClientRepozitory;
        private readonly IRepository<DataOfIndividualClient> dataIndividualClientRepozitory;
        private readonly IDeletableEntityRepository<DepositedMoney> depositMoneyRepozitory;
        private readonly IRepository<Division> divisionRepozitory;
        private readonly IDeletableEntityRepository<FinancialInstrument> finInstrRepozitory;
        private readonly IRepository<IdentityDocument> identityDocRepozitory;
        private readonly IDeletableEntityRepository<Order> orderRepozitory;
        private readonly IDeletableEntityRepository<Town> townRepozitory;
        private readonly IDeletableEntityRepository<Trade> tradeRepozitory;
        private readonly IDeletableEntityRepository<TradeOrder> tradeOrderRepozitory;
        private readonly IClientService clientService;
        private readonly IEmployeeService employeeService;
        private readonly IFinancialInstrumentService financialInstrumentService;

        public OrderService(
                   IDeletableEntityRepository<Employee> employeeRepozitory
                   , IDeletableEntityRepository<ApplicationUser> aplicationUserRepozitory
                   , IDeletableEntityRepository<Client> clientRepozitory
                   , IDeletableEntityRepository<ClientFinancialInstrument> clientFinancialInstrumentRepozitory
                   , IRepository<Country> countryRepozitory
                   , IRepository<DataOfCorporateveClient> dataCorporativeClientRepozitory
                   , IRepository<DataOfIndividualClient> dataIndividualClientRepozitory
                   , IDeletableEntityRepository<DepositedMoney> depositMoneyRepozitory
                   , IRepository<Division> divisionRepozitory
                   , IDeletableEntityRepository<FinancialInstrument> finInstrRepozitory
                   , IRepository<IdentityDocument> identityDocRepozitory
                   , IDeletableEntityRepository<Order> orderRepozitory
                   , IDeletableEntityRepository<Town> townRepozitory
                   , IDeletableEntityRepository<Trade> tradeRepozitory
                   , IDeletableEntityRepository<TradeOrder> tradeOrderRepozitory
                   , IClientService clientService
                    ,IEmployeeService employeeService
                    ,IFinancialInstrumentService financialInstrumentService)
        

        {
            this.employeeRepozitory = employeeRepozitory;
            this.aplicationUserRepozitory = aplicationUserRepozitory;
            this.clientRepozitory = clientRepozitory;
            this.clientFinancialInstrumentRepozitory = clientFinancialInstrumentRepozitory;
            this.countryRepozitory = countryRepozitory;
            this.dataCorporativeClientRepozitory = dataCorporativeClientRepozitory;
            this.dataIndividualClientRepozitory = dataIndividualClientRepozitory;
            this.depositMoneyRepozitory = depositMoneyRepozitory;
            this.divisionRepozitory = divisionRepozitory;
            this.finInstrRepozitory = finInstrRepozitory;
            this.identityDocRepozitory = identityDocRepozitory;
            this.orderRepozitory = orderRepozitory;
            this.townRepozitory = townRepozitory;
            this.tradeRepozitory = tradeRepozitory;
            this.tradeOrderRepozitory = tradeOrderRepozitory;
            this.clientService = clientService;
            this.employeeService = employeeService;
            this.financialInstrumentService = financialInstrumentService;
        }

        public async Task<Guid> CreateAsync(OrderFormModel model, Guid? clientId)
        {
            if (await financialInstrumentService.ExixtFinancialInstrumentAsync(model.FinancialInstrumentId) == false)
            {
                throw new NonFinancialInstrumentException(MessageNotFinancialInstrumentException);
            }

            if(clientId == null)
            {
                throw new UnauthoriseActionException(MessageUnauthoriseActionException);
            }

            if (await NotEnoughMoneyAsync(clientId, (model.Price * model.InitialVolume)) == false) 
            {
                throw new Exception(DoNotEnoughMoney);
            }

            var order = new Order()
            {
                IsBid = model.IsBid,
                InitialVolume = model.InitialVolume,
                ActiveVolume = model.InitialVolume,
                Price = model.Price,
                FinancialInstrumentId = model.FinancialInstrumentId,
                ClientId = clientId ?? new Guid(),
            };

            await orderRepozitory.AddAsync(order);
            await orderRepozitory.SaveChangesAsync();

            await ChechOrderForExecuting(order);

            return order.Id;
        }

        private async Task ChechOrderForExecuting(Order order)
        {
            var opositOrders = order.IsBid
                ? await orderRepozitory.All()
                    .Where(o => o.IsBid == false 
                        && o.FinancialInstrumentId == order.FinancialInstrumentId
                        && o.ClientId != order.ClientId
                        && o.Price <= order.Price)
                    .OrderBy(o => o.Price)
                    .ThenByDescending(o => o.CreatedOn)
                    .ToListAsync()
                : await orderRepozitory.All()
                    .Where(o => o.IsBid 
                        && o.FinancialInstrumentId == order.FinancialInstrumentId
                        && o.ClientId != order.ClientId
                        && o.Price >= order.Price)
                    .OrderByDescending(o => o.Price)
                    .ThenByDescending(o => o.CreatedOn)
                    .ToListAsync();

            if(opositOrders != null)
            {
                List<Trade> trades = new List<Trade>();
                List<TradeOrder> tradeOrders = new List<TradeOrder>();

                for (int i = opositOrders.Count() - 1; i >=0; i-- )
                {
                    var value = opositOrders[i].ActiveVolume > order.ActiveVolume
                        ? order.ActiveVolume
                        : opositOrders[i].ActiveVolume;

                    var trade = new Trade()
                    {
                        Volume = value,
                        Price = opositOrders[i].Price,
                        FinancialInstrumentId = order.FinancialInstrumentId,
                    };

                    trades.Add(trade);

                    var tradeOrdersOne = new TradeOrder()
                    {
                        Trade = trade,
                        OrderId = order.Id,
                        Volume = value,
                    };

                    tradeOrders.Add(tradeOrdersOne);

                    var tradeOrdersSecond = new TradeOrder()
                    {
                        Trade = trade,
                        OrderId = opositOrders[i].Id,
                        Volume = value,
                    };

                    tradeOrders.Add(tradeOrdersSecond);

                    var bidderId = order.IsBid
                        ? order.ClientId
                        : opositOrders[i].ClientId;

                    var sellerId = order.IsBid
                        ? order.ClientId
                        : opositOrders[i].ClientId;

                    await ExecutingSettelmentTrade(sellerId, bidderId, trade.Volume, order, trade.Price);

                    opositOrders[i].ActiveVolume -= value;
                    order.ActiveVolume -= value;

                    if (order.ActiveVolume == 0)
                    {
                        break;
                    }

                    await tradeOrderRepozitory.SaveChangesAsync();
                    await tradeRepozitory.SaveChangesAsync();
                    await orderRepozitory.SaveChangesAsync();
                }
            }
        }

        private async Task ExecutingSettelmentTrade(Guid sellerId, Guid bidderId, uint volume, Order order, decimal priceExecuting)
        {
            var counterparty = order.ClientId == sellerId
                ? await clientRepozitory.All().Where(c => c.Id == bidderId).FirstAsync()
                : await clientRepozitory.All().Where(c => c.Id == sellerId).FirstAsync();

            if (order.IsBid)
            {
                order.Client.BlockedSum -= volume * order.Price;
                order.Client.Balance = order.Price > priceExecuting
                    ? order.Client.Balance + ((order.Price - priceExecuting) * volume)
                    : order.Client.Balance;

                counterparty.Balance += volume * order.Price;
            }
            if (order.IsBid == false)
            {
                counterparty.BlockedSum -= volume * priceExecuting;

                order.Client.Balance += volume * order.Price;
            }

            await FinacialInstrumentSettelment(order.Client, volume, order.IsBid, order.FinancialInstrumentId);
            await FinacialInstrumentSettelment(counterparty, volume, order.IsBid, order.FinancialInstrumentId);
        }

        private async Task FinacialInstrumentSettelment(Client client, uint volume, bool isBid, int finInstrId)
        {            
             if (client.FinancialInstruments.Any(si => si.FinancialInstrumentId == finInstrId))
             {
                 var clientFinInsr = await clientFinancialInstrumentRepozitory.All()
                          .Where(f => f.FinancialInstrumentId == finInstrId
                              && f.ClientId == client.Id)
                          .FirstAsync();

                 clientFinInsr.Volume = isBid ? clientFinInsr.Volume + volume
                    : clientFinInsr.Volume - volume;

                 
             }
             else
             {
                var clientFinInstr = new ClientFinancialInstrument()
                {
                    ClientId = client.Id,
                    FinancialInstrumentId = finInstrId,
                    Volume = volume,
                };

                await clientFinancialInstrumentRepozitory.AddAsync(clientFinInstr);
             }

            await clientFinancialInstrumentRepozitory.SaveChangesAsync();
        }

        public async Task<OrderDetailsServiceModel> GetOrderDetailsByIdAsync(Guid orderId, Guid userId)
        {
            var entity = await GetOrderByIdAsync(orderId);

            var clientId = await clientService.GetClientIdByUserIdAsync(userId);

            if (entity == null)
            {
                throw new Exception(MessageNotDataException);
            }

            if((clientId == null 
                || entity.ClientId !=  clientId )
                && await employeeService.ExistsByUserIdAsync(userId) == false)
            {
                throw new UnauthoriseActionException(MessageUnauthoriseActionException);
            }

            return new OrderDetailsServiceModel()
            {
                Id = entity.Id,
                Price = entity.Price,
                FinancialInstrumentId = entity.FinancialInstrumentId,
                InitialVolume = entity.InitialVolume,
                UnfulfilledVolume = entity.ActiveVolume,
                FinancialInstrumentName = await finInstrRepozitory.AllAsNoTracking().Where(f => f.Id == entity.FinancialInstrumentId).Select(f => f.Name).FirstOrDefaultAsync() ?? string.Empty,
                IsDelete = entity.IsDeleted
            };
        }

        public async Task<Order?> GetOrderByIdAsync(Guid orderId)
        {
            return await orderRepozitory.AllAsNoTrackingWithDeleted().Where(o => o.Id == orderId)
                .FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(Guid orderId, Guid userId)
        {
            var entity = await GetOrderByIdAsync(orderId);
            var clientId = await clientService.GetClientIdByUserIdAsync(userId);

            if (entity == null
                || entity.IsDeleted)
            {
                throw new Exception(MessageNotDataException);
            }

            if (clientId == null
                || entity.ClientId != clientId
                || await employeeService.ExistsByUserIdAsync(userId) == false)
            {
                throw new UnauthoriseActionException(MessageUnauthoriseActionException);
            }

            orderRepozitory.Delete(entity);
            await orderRepozitory.SaveChangesAsync();
        }
        

        public async Task<OrderQueryServiceModel> AllAsyn(
            Guid userId
            , string? ClientAccountId = null
            , bool? IsBid = null
            , bool? IsNotActive = null
            , string? ISIN = null
            , string? searchTerm = null
            , OrderSorting sorting = OrderSorting.Newest
            , int currentPage = 1
            , int ordersPerPage = 1)
        {
            var clientId = await clientService.GetClientIdByUserIdAsync(userId);

            if (clientId == null
                && await employeeService.ExistsByUserIdAsync(userId) == false)
            {
                throw new UnauthoriseActionException(MessageUnauthoriseActionException);
            }

            var ordersToShow = orderRepozitory.AllAsNoTrackingWithDeleted();

            if (ISIN != null)
            {
                ordersToShow = ordersToShow
                    .Where(o => o.FinancialInstrument.ISIN == ISIN);
            }
            
            if (ClientAccountId != null
                && Guid.TryParse(ClientAccountId, out Guid id)
                && (await clientService.ExistClientByIdAsync(id)))
            {
                ordersToShow = ordersToShow
                    .Where(o => o.ClientId == id);
            }

            if (IsNotActive != null)
            {
                ordersToShow = ordersToShow
                    .Where(o => o.IsDeleted == IsNotActive);
            }

            if (IsBid != null)
            {
                ordersToShow = ordersToShow
                    .Where(o => o.IsBid == IsBid);
            }

            if (searchTerm != null)
            {
                string normalizedSearcTerm = searchTerm.ToLower();

                ordersToShow = ordersToShow
                    .Where(o => o.Price.ToString().ToLower().Contains(normalizedSearcTerm)
                        || o.FinancialInstrument.Name.ToLower().Contains(normalizedSearcTerm)
                        || o.CreatedOn.ToString().ToLower().Contains(normalizedSearcTerm)
                        || o.ClientId.ToString().ToLower().Contains(normalizedSearcTerm));
            }

            ordersToShow = sorting switch
            {
                OrderSorting.FinancialInstrument => ordersToShow
                    .OrderBy(o => o.FinancialInstrument.Name)
                    .ThenByDescending(o => o.CreatedOn),
                OrderSorting.Client => ordersToShow
                    .OrderBy(o => o.Client.Id)
                    .ThenByDescending(f => f.CreatedOn),
                _ => ordersToShow
                    .OrderByDescending(o => o.CreatedOn),
            };

            if(clientId != null)
            {
                ordersToShow = ordersToShow.Where(o => o.ClientId == clientId);
            }

            var orders = await ordersToShow
                .Skip((currentPage - 1) * ordersPerPage)
                .Take(ordersPerPage)
                .Select(o => new OrderDetailsServiceModel()
                {
                    Id = o.Id,
                    FinancialInstrumentName = o.FinancialInstrument.Name,
                    UnfulfilledVolume = o.ActiveVolume,
                    IsBid = o.IsBid,
                    InitialVolume = o.InitialVolume,
                    Price = o.Price,
                    FinancialInstrumentId = o.FinancialInstrumentId,
                })
                .ToListAsync();

            int totalOrders = clientId != null
                ? await orderRepozitory.AllAsNoTrackingWithDeleted().Where(o => o.ClientId == clientId).CountAsync()
                : await orderRepozitory.AllAsNoTrackingWithDeleted().CountAsync();

            return new OrderQueryServiceModel()
            {
                Orders = orders,
                TotalOrdersCount = totalOrders,
            };
        }

        private async Task<bool> NotEnoughMoneyAsync(Guid? clientId, decimal sum)
        {          

            Client client = await clientRepozitory.AllAsNoTracking().Where(c => c.Id == clientId).FirstAsync();

            return client.Balance >= sum;
        }

        public async Task<decimal> GetBalanceByUserIdAsync(Guid userId)
        {
            var clientId = await clientService.GetClientIdByUserIdAsync(userId);

            if (clientId == null)
            {
                throw new UnauthoriseActionException(MessageUnauthoriseActionException);
            }

            Client client = await clientRepozitory.AllAsNoTracking().Where(c => c.Id == clientId).FirstAsync();

            return client.Balance;
        }

        public async Task<bool> ExistOrderByIdAsync(Guid orderId)
        {
            return await orderRepozitory.AllAsNoTrackingWithDeleted().AnyAsync(o => o.Id == orderId);
        }
    }
}
