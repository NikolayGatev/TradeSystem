using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Models.Enums;
using TradeSystem.Core.Models.Orders;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;
using static TradeSystem.Common.ExceptionMessages;
using static TradeSystem.Common.MessageConstants;

namespace TradeSystem.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDeletableEntityRepository<Client> clientRepozitory;
        private readonly IDeletableEntityRepository<ClientFinancialInstrument> clientFinancialInstrumentRepozitory;
        private readonly IDeletableEntityRepository<FinancialInstrument> finInstrRepozitory;
        private readonly IDeletableEntityRepository<Order> orderRepozitory;
        private readonly IDeletableEntityRepository<Trade> tradeRepozitory;
        private readonly IDeletableEntityRepository<TradeOrder> tradeOrderRepozitory;
        private readonly IClientService clientService;
        private readonly IEmployeeService employeeService;
        private readonly IFinancialInstrumentService financialInstrumentService;

        public OrderService( IDeletableEntityRepository<Client> clientRepozitory
                   , IDeletableEntityRepository<ClientFinancialInstrument> clientFinancialInstrumentRepozitory
                   , IDeletableEntityRepository<FinancialInstrument> finInstrRepozitory
                   , IDeletableEntityRepository<Order> orderRepozitory
                   , IDeletableEntityRepository<Trade> tradeRepozitory
                   , IDeletableEntityRepository<TradeOrder> tradeOrderRepozitory
                   , IClientService clientService
                    ,IEmployeeService employeeService
                    ,IFinancialInstrumentService financialInstrumentService)
        

        {
            this.clientRepozitory = clientRepozitory;
            this.clientFinancialInstrumentRepozitory = clientFinancialInstrumentRepozitory;
            this.finInstrRepozitory = finInstrRepozitory;
            this.orderRepozitory = orderRepozitory;
            this.tradeRepozitory = tradeRepozitory;
            this.tradeOrderRepozitory = tradeOrderRepozitory;
            this.clientService = clientService;
            this.employeeService = employeeService;
            this.financialInstrumentService = financialInstrumentService;
        }

        public async Task<Guid> CreateAsync(OrderFormModel model, Guid clientId)
        {
            var client = await clientService.GetClientByClientIdAcync(clientId);

            if (await financialInstrumentService.ExixtFinancialInstrumentAsync(model.FinancialInstrumentId) == false)
            {
                throw new NonFinancialInstrumentException(MessageNotFinancialInstrumentException);
            }

            if(client == null)
            {
                throw new UnauthoriseActionException(MessageUnauthoriseActionException);
            }

            if (model.IsBid && await NotEnoughMoneyAsync(clientId, (model.Price * model.InitialVolume)) == false) 
            {
                throw new NonEnoughMoney(DoNotEnoughMoney);
            }

            if(model.IsBid == false && await EnoughFinancialInstrumentsAsync(clientId, model.InitialVolume, model.FinancialInstrumentId) == false)
            {
                throw new NonEnoughFinancialInstrument(DoNotEnoughFinancialInstruments);
            }

            var order = new Order()
            {
                IsBid = model.IsBid,
                InitialVolume = model.InitialVolume,
                ActiveVolume = model.InitialVolume,
                Price = model.Price,
                FinancialInstrumentId = model.FinancialInstrumentId,
                ClientId = clientId,
            };

            if(model.IsBid)
            {
                client.BlockedSum = model.InitialVolume * model.Price;
                client.Balance -= model.InitialVolume * model.Price;

                await clientRepozitory.SaveChangesAsync();
            }

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

            if(opositOrders.Any())

                for (int i = 0; i < opositOrders.Count(); i++ )
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

                    await tradeRepozitory.AddAsync(trade);
                    await tradeRepozitory.SaveChangesAsync();

                    var tradeOrdersOne = new TradeOrder()
                    {
                        TradeId = trade.Id,
                        OrderId = order.Id,
                        Volume = value,
                    };

                    await tradeOrderRepozitory.AddAsync(tradeOrdersOne);

                    var tradeOrdersSecond = new TradeOrder()
                    {
                        TradeId = trade.Id,
                        OrderId = opositOrders[i].Id,
                        Volume = value,
                    };

                    await tradeOrderRepozitory.AddAsync(tradeOrdersSecond);

                    await tradeOrderRepozitory.SaveChangesAsync();

                    var bidderId = order.IsBid
                        ? order.ClientId
                        : opositOrders[i].ClientId;

                    var sellerId = order.IsBid
                        ? opositOrders[i].ClientId
                        : order.ClientId;

                    await ExecutingSettelmentTrade(sellerId, bidderId, trade.Volume, order, trade.Price);

                    opositOrders[i].ActiveVolume -= value;
                    order.ActiveVolume -= value;

                    if (opositOrders[i].ActiveVolume == 0)
                    {
                        orderRepozitory.Delete(opositOrders[i]);
                    }

                    if (order.ActiveVolume == 0)
                    {
                        orderRepozitory.Delete(order);
                    }

                    await orderRepozitory.SaveChangesAsync();

                    if (order.ActiveVolume == 0)
                    {
                        break;
                    }
                }
            }
        


        private async Task ExecutingSettelmentTrade(Guid sellerId, Guid bidderId, uint volume, Order order, decimal priceExecuting)
        {
            var counterparty = order.ClientId == sellerId
                ? await clientRepozitory.All().Where(c => c.Id == bidderId).FirstAsync()
                : await clientRepozitory.All().Where(c => c.Id == sellerId).FirstAsync();

            var client = await clientRepozitory.All().Where(c => c.Id == order.ClientId).FirstAsync();

            if (order.IsBid)
            {
                client.BlockedSum -= volume * order.Price;
                client.Balance = order.Price > priceExecuting
                    ? client.Balance + ((order.Price - priceExecuting) * volume)
                    : client.Balance;

                counterparty.Balance += volume * priceExecuting;
            }
            if (order.IsBid == false)
            {
                counterparty.BlockedSum -= volume * priceExecuting;

                client.Balance += volume * priceExecuting;
            }

            await clientRepozitory.SaveChangesAsync();

            await FinacialInstrumentSettelment(client, volume, order.IsBid, order.FinancialInstrumentId);
            await FinacialInstrumentSettelment(counterparty, volume, order.IsBid ? false : true, order.FinancialInstrumentId);
        }

        private async Task FinacialInstrumentSettelment(Client client, uint volume, bool isBid, int finInstrId)
        {
            var clientFinInsr = await clientFinancialInstrumentRepozitory.All()
                          .Where(f => f.FinancialInstrumentId == finInstrId
                              && f.ClientId == client.Id)
                          .FirstOrDefaultAsync();

            if (clientFinInsr != null)
             {
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

        public async Task<OrderDetailsServiceModel> GetOrderDetailsByIdAsync(Guid orderId, string userId)
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
                IsBid = entity.IsBid,
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

        public async Task DeleteAsync(Guid orderId, string userId)
        {
            var entity = await GetOrderByIdAsync(orderId);
            var clientIdByUserId = await clientService.GetClientIdByUserIdAsync(userId);

            if (entity == null
                || entity.IsDeleted)
            {
                throw new Exception(MessageNotDataException);
            }

            var clientSubmitEntity = await clientService.GetClientByClientIdAcync(entity.ClientId);

            if ((await employeeService.ExistsByUserIdAsync(userId) == false)
                 && (clientIdByUserId == null || (entity.ClientId != clientIdByUserId)))
            {
                throw new UnauthoriseActionException(MessageUnauthoriseActionException);
            }

            if(clientSubmitEntity == null)
            {
                throw new UnauthoriseActionException(MessageUnauthoriseActionException);
            }

            if(entity.IsBid)
            {
                clientSubmitEntity.BlockedSum -= entity.Price * entity.ActiveVolume;
                clientSubmitEntity.Balance += entity.Price * entity.ActiveVolume;

                await clientRepozitory.SaveChangesAsync();
            }

            orderRepozitory.Delete(entity);
            await orderRepozitory.SaveChangesAsync();
        }        

        public async Task<OrderQueryServiceModel> AllAsyn(
            string userId
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
                    IsDelete = o.IsDeleted,
                    FinancialInstrumentId = o.FinancialInstrumentId,
                    ClientId = o.ClientId,
                    
                })
                .ToListAsync();

            int totalOrders = clientId != null
                ? await ordersToShow.Where(o => o.ClientId == clientId).CountAsync()
                : await ordersToShow.CountAsync();

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

        public async Task<decimal> GetBalanceByUserIdAsync(string userId)
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


        private async Task<bool> EnoughFinancialInstrumentsAsync(Guid? clientId, uint initialVolume, int finInstrId)
        {
            uint ownerFinIstr = (uint) await financialInstrumentService.GetCountOfOwnerFinancialInstrumentOnClientByIdAsync(clientId, finInstrId);

            var AllSellOrders = (uint) await orderRepozitory.AllAsNoTracking()
                .Where(o => o.ClientId == clientId && o.FinancialInstrumentId == finInstrId && o.IsBid == false)
                .Select(o => (int)o.ActiveVolume).SumAsync();

            return (AllSellOrders + initialVolume) <= ownerFinIstr; 
        }

        public async Task DeleteAllOredersByFinancialInstrumentAsync(int financialInstrumentId, string userId)
        {
            var orders = await orderRepozitory.All()
                .Where(o => o.FinancialInstrumentId == financialInstrumentId)
                .Select(o => o.Id)
                .ToListAsync();

            foreach (var orderId in orders) 
            {
                try
                {
                    await DeleteAsync(orderId, userId);
                }
                catch (UnauthoriseActionException )
                {                    
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
