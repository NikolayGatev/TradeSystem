using Microsoft.EntityFrameworkCore;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Models.Enums;
using TradeSystem.Core.Models.FinacialInstrument;
using TradeSystem.Core.Models.Orders;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;
using static TradeSystem.Common.ExceptionMessages;

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
                    ,IEmployeeService employeeService)

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
        }

        public async Task<IEnumerable<FinInstrumentServiceModel>> AllFinancialInstrumentsAsync()
        {
            return await finInstrRepozitory.AllAsNoTracking()
                .Select(f => new FinInstrumentServiceModel()
                {
                    Id = f.Id,
                    Name = f.Name,
                })
                .OrderBy(f => f.Name)
                .ToListAsync();
        }

        public async Task<Guid> CreateAsync(OrderFormModel model, Guid? clientId)
        {
            if (await finInstrRepozitory.AllAsNoTracking().AnyAsync(f => f.Id == model.FinancialInstrumentId) == false)
            {
                throw new NotFinancialInstrumentException(MessageNotFinancialInstrumentException);
            }

            if(clientId == null)
            {
                throw new UnauthoriseActionException(MessageUnauthoriseActionException);
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

            return order.Id;
        }

        public async Task<OrderDetailsServiceModel> GetOrderDetailsByIdAsync(Guid orderId, Guid userId)
        {
            var entity = await GetOrderByIdAsync(orderId);
            var clientId = await clientService.GetClientByUserIdAsync(userId);

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
            return await orderRepozitory.AllAsNoTracking().Where(o => o.Id == orderId)
                .FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(Guid orderId, Guid userId)
        {
            var entity = await GetOrderByIdAsync(orderId);
            var clientId = await clientService.GetClientByUserIdAsync(userId);

            if (entity == null)
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
            var clientId = await clientService.GetClientByUserIdAsync(userId);

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

        public async Task<IEnumerable<string>> AllClintsIdAsync(Guid userId)
        {
            var clientId = await clientService.GetClientByUserIdAsync(userId);

            return clientId != null
                ? new List<string>() { clientId.ToString() }
                : await clientRepozitory.AllAsNoTrackingWithDeleted()
                .Select(c => c.Id.ToString())
                .OrderBy(c => c)
                .ToListAsync();
        }
    }
}
