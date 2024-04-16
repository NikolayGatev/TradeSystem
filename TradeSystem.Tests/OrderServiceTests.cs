using Microsoft.EntityFrameworkCore;
using Moq;
using TradeSystem.Core.Contracts;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;
using TradeSystem.Data.Repositories;
using TradeSystem.Data;
using TradeSystem.Core.Services;
using TradeSystem.Core.Models.Orders;
using TradeSystem.Core.Models.Clients;
using TradeSystem.Core.Exeptions;
using static TradeSystem.Common.ExceptionMessages;
using TradeSystem.Core.Models.Enums;
using System;
using System.Security.Cryptography;

namespace TradeSystem.Tests
{
    [TestFixture]

    public class OrderServiceTests
    {
        private DbContextOptions<TradeSystemDbContext> dbOptions;
        private TradeSystemDbContext dbContext;

        private IDeletableEntityRepository<Client> clientRepozitory;
        private IDeletableEntityRepository<ClientFinancialInstrument> clientFinancialInstrumentRepozitory;
        private IDeletableEntityRepository<FinancialInstrument> finInstrRepozitory;
        private IDeletableEntityRepository<Order> orderRepozitory;
        private IDeletableEntityRepository<Trade> tradeRepozitory;
        private IDeletableEntityRepository<TradeOrder> tradeOrderRepozitory;
        private Mock<IClientService> mockClientService;
        private Mock<IEmployeeService> mockEmployeeService;
        private Mock<IFinancialInstrumentService> mockFinancialInstrumentService;

        private IOrderService orderService;

        [SetUp]
        public async Task OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TradeSystemDbContext>()
                .UseInMemoryDatabase("HouseRentingInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new TradeSystemDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            TradeSystem.Tests.SeedDatabase.DatabaseSeeder.SeedDatabase(this.dbContext);

            clientRepozitory = new EfDeletableEntityRepository<Client>(dbContext);
            clientFinancialInstrumentRepozitory = new EfDeletableEntityRepository<ClientFinancialInstrument>(dbContext);
            finInstrRepozitory = new EfDeletableEntityRepository<FinancialInstrument>(dbContext);
            orderRepozitory = new EfDeletableEntityRepository<Order>(dbContext);
            tradeRepozitory = new EfDeletableEntityRepository<Trade>(dbContext);
            tradeOrderRepozitory = new EfDeletableEntityRepository<TradeOrder>(dbContext);

            mockClientService = new Mock<IClientService>();
            var client = await dbContext.Clients.FirstAsync();

            mockClientService.Setup(x => x.GetClientByClientIdAcync(client.Id))
                    .ReturnsAsync(client);
            mockClientService.Setup(x => x.GetClientIdByUserIdAsync("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"))
                    .ReturnsAsync(client.Id);

            mockEmployeeService = new Mock<IEmployeeService>();
            mockEmployeeService.Setup(x => x.ExistsByUserIdAsync(new Guid().ToString()))
                .ReturnsAsync(false);

            mockFinancialInstrumentService = new Mock<IFinancialInstrumentService>();
            mockFinancialInstrumentService.Setup(x => x.ExixtFinancialInstrumentAsync(1))
                .ReturnsAsync(true);
            mockFinancialInstrumentService.Setup(x => x.ExixtFinancialInstrumentAsync(3))
                .ReturnsAsync(true);
            mockFinancialInstrumentService.Setup(x => x.ExixtFinancialInstrumentAsync(6))
                .ReturnsAsync(false);

            orderService = new OrderService(
                clientRepozitory
                , clientFinancialInstrumentRepozitory
                , finInstrRepozitory
                , orderRepozitory
                , tradeRepozitory
                , tradeOrderRepozitory
                , mockClientService.Object
                , mockEmployeeService.Object
                , mockFinancialInstrumentService.Object);
        }

        [Test]

        public async Task CreateAsync_Correct()
        {
            var client = await dbContext.Clients.FirstAsync();

            var model = new OrderFormModel()
            {
                Balance = client.Balance,
                IsBid = true,
                InitialVolume = 10,
                Price = 10,
                FinancialInstrumentId = 1,
            };

            var result = await orderService.CreateAsync(model, client.Id);

            var newOrderId = await dbContext.Orders.FirstAsync(x => x.Id == result);

            Assert.That(result, Is.EqualTo(newOrderId.Id));
        }

        [Test]

        public async Task CreateAsync_NonFinancialInstrumentException()
        {
            var client = await dbContext.Clients.FirstAsync();

            var model = new OrderFormModel()
            {
                Balance = client.Balance,
                IsBid = true,
                InitialVolume = 10,
                Price = 10,
                FinancialInstrumentId = 6,
            };

            Assert.ThrowsAsync<NonFinancialInstrumentException>(async () => await orderService.CreateAsync(model, client.Id));
        }

        [Test]

        public async Task CreateAsync_UnauthoriseActionException()
        {
            var client = await dbContext.Clients.FirstAsync();

            var model = new OrderFormModel()
            {
                Balance = client.Balance,
                IsBid = true,
                InitialVolume = 10,
                Price = 10,
                FinancialInstrumentId = 1,
            };

            Assert.ThrowsAsync<UnauthoriseActionException>(async () => await orderService.CreateAsync(model, new Guid()));
        }

        [Test]

        public async Task CreateAsync_NonEnoughMoney()
        {
            var client = await dbContext.Clients.FirstAsync();

            var model = new OrderFormModel()
            {
                Balance = client.Balance,
                IsBid = true,
                InitialVolume = 5000,
                Price = 20,
                FinancialInstrumentId = 1,
            };

            Assert.ThrowsAsync<NonEnoughMoney>(async () => await orderService.CreateAsync(model, client.Id));
        }

        [Test]

        public async Task CreateAsync_NonEnoughFinancialInstrumentn()
        {
            var client = await dbContext.Clients.FirstAsync();

            var model = new OrderFormModel()
            {
                Balance = client.Balance,
                IsBid = false,
                InitialVolume = 10,
                Price = 10,
                FinancialInstrumentId = 1,
            };

            Assert.ThrowsAsync<NonEnoughFinancialInstrument>(async () => await orderService.CreateAsync(model, client.Id));
        }

        [Test]

        public async Task ChechOrderForExecuting_WithBidOrderExecutingFull()
        {
            var client = await dbContext.Clients.FirstAsync();

            var model = new OrderFormModel()
            {
                Balance = client.Balance,
                IsBid = true,
                InitialVolume = 10,
                Price = 100,
                FinancialInstrumentId = 3,
            };

            var orderId = await orderService.CreateAsync(model, client.Id);

            var result = await dbContext.TradeOrders.Where(x => x.OrderId == orderId).FirstOrDefaultAsync();

            Assert.IsNotNull(result);
        }

        [Test]

        public async Task ChechOrderForExecuting_WithBidOrderExecutingNotFull()
        {
            var client = await dbContext.Clients.FirstAsync();

            var model = new OrderFormModel()
            {
                Balance = client.Balance,
                IsBid = true,
                InitialVolume = 101,
                Price = 100,
                FinancialInstrumentId = 3,
            };

            var orderId = await orderService.CreateAsync(model, client.Id);

            var result = await dbContext.Orders.Where(x => x.Id == orderId).Select(x => x.ActiveVolume).FirstOrDefaultAsync();

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]

        public async Task GetOrderDetailsByIdAsync_Correct()
        {
            var clientData = await dbContext.DataOfIndividualClients.FirstAsync();

            var order = await dbContext.Orders.FirstAsync(o => o.ClientId == clientData.ClientId && o.IsDeleted == false);

            var result = await orderService.GetOrderDetailsByIdAsync(order.Id, clientData.ApplicationUserId);

            Assert.That(result.Id, Is.EqualTo(order.Id));
        }

        [Test]

        public void GetOrderDetailsByIdAsync_Exception_NonCorectOrderId()
        {
            var exception = Assert.ThrowsAsync<Exception>(async () => await orderService.GetOrderDetailsByIdAsync(new Guid(), new Guid().ToString()));

            Assert.That(exception.Message, Is.EqualTo(MessageNotDataException));
        }

        [Test]

        public async Task GetOrderDetailsByIdAsync_Exception_UnauthoriseActionException()
        {
            var order = await dbContext.Orders.FirstAsync(o => o.IsDeleted == false);

            var exception = Assert.ThrowsAsync<UnauthoriseActionException>(async () => await orderService.GetOrderDetailsByIdAsync(order.Id, new Guid().ToString()));

            Assert.That(exception.Message, Is.EqualTo(MessageUnauthoriseActionException));
        }

        [Test]

        public async Task DeleteAsync_Correct()
        {
            var clientData = await dbContext.DataOfIndividualClients.FirstAsync();

            var model = await dbContext.Orders.CountAsync(o => o.IsDeleted);

            var orderId = await dbContext.Orders.Where(o => o.ClientId == clientData.ClientId && o.IsDeleted == false).Select(o => o.Id).FirstOrDefaultAsync();

            await orderService.DeleteAsync(orderId, clientData.ApplicationUserId);

            var result = await dbContext.Orders.CountAsync(o => o.IsDeleted);

            Assert.That(result, Is.EqualTo(model + 1));
        }               

        [Test]

        public void GDeleteAsync_Exception_NonCorectOrderId()
        {
            var exception = Assert.ThrowsAsync<Exception>(async () => await orderService.DeleteAsync(new Guid(), new Guid().ToString()));

            Assert.That(exception.Message, Is.EqualTo(MessageNotDataException));
        }

        [Test]

        public async Task DeleteAsync_Exception_UnauthoriseActionException()
        {
            var order = await dbContext.Orders.FirstAsync(o => o.IsDeleted == false);

            var exception = Assert.ThrowsAsync<UnauthoriseActionException>(async () => await orderService.DeleteAsync(order.Id, new Guid().ToString()));

            Assert.That(exception.Message, Is.EqualTo(MessageUnauthoriseActionException));
        }

        [Test]

        public async Task AllAsyn_WithAllChechingNull()
        {
            var clientData = await dbContext.DataOfIndividualClients.FirstAsync();

            var model = await dbContext.Orders.Where(o => o.ClientId == clientData.ClientId).CountAsync();

            string userId = clientData.ApplicationUserId;
            string? clientAccountId = null;
            bool? isBid = null;
            bool? isNotActive = null;
            string? ISIN = null;
            string? searchTerm = null;
            OrderSorting sorting = OrderSorting.Newest;
            int currentPage = 1;
            int ordersPerPage = 1;

            var result = await orderService.AllAsyn(
                userId
                ,clientAccountId
                ,isBid
                ,isNotActive
                ,ISIN
                ,searchTerm
                ,sorting
                ,currentPage
                ,ordersPerPage);

            Assert.That(result.TotalOrdersCount, Is.EqualTo(model));
        }

        [Test]

        public async Task AllAsyn_WithISINNonNull()
        {
            var isin = await dbContext.FinancialInstruments.Select(f => f.ISIN).FirstAsync();

            var clientData = await dbContext.DataOfIndividualClients.FirstAsync();

            var model = await dbContext.Orders.Where(o => o.ClientId == clientData.ClientId && o.FinancialInstrument.ISIN == isin).CountAsync();

            string userId = clientData.ApplicationUserId;
            string? clientAccountId = null;
            bool? isBid = null;
            bool? isNotActive = null;
            string? ISIN = isin;
            string? searchTerm = null;
            OrderSorting sorting = OrderSorting.Newest;
            int currentPage = 1;
            int ordersPerPage = 1;

            var result = await orderService.AllAsyn(
                userId
                , clientAccountId
                , isBid
                , isNotActive
                , ISIN
                , searchTerm
                , sorting
                , currentPage
                , ordersPerPage);

            Assert.That(result.TotalOrdersCount, Is.EqualTo(model));
        }

        [Test]

        public async Task AllAsyn_WithClientAcountNonNull()
        {
            var clientData = await dbContext.DataOfIndividualClients.FirstAsync();

            var model = await dbContext.Orders.Where(o => o.ClientId == clientData.ClientId).CountAsync();

            string userId = clientData.ApplicationUserId;
            string? clientAccountId = clientData.ClientId.ToString();
            bool? isBid = null;
            bool? isNotActive = null;
            string? ISIN = null;
            string? searchTerm = null;
            OrderSorting sorting = OrderSorting.Newest;
            int currentPage = 1;
            int ordersPerPage = 1;

            var result = await orderService.AllAsyn(
                userId
                , clientAccountId
                , isBid
                , isNotActive
                , ISIN
                , searchTerm
                , sorting
                , currentPage
                , ordersPerPage);

            Assert.That(result.TotalOrdersCount, Is.EqualTo(model));
        }

        [Test]

        public async Task AllAsyn_WithIsNotActiveNonNull()
        {
            var clientData = await dbContext.DataOfIndividualClients.FirstAsync();

            var model = await dbContext.Orders.Where(o => o.ClientId == clientData.ClientId && o.IsDeleted).CountAsync();

            string userId = clientData.ApplicationUserId;
            string? clientAccountId = null;
            bool? isBid = null;
            bool? isNotActive = true;
            string? ISIN = null;
            string? searchTerm = null;
            OrderSorting sorting = OrderSorting.Newest;
            int currentPage = 1;
            int ordersPerPage = 1;

            var result = await orderService.AllAsyn(
                userId
                , clientAccountId
                , isBid
                , isNotActive
                , ISIN
                , searchTerm
                , sorting
                , currentPage
                , ordersPerPage);

            Assert.That(result.TotalOrdersCount, Is.EqualTo(model));
        }

        [Test]

        public async Task AllAsyn_WithIsBidNonNull()
        {
            var clientData = await dbContext.DataOfIndividualClients.FirstAsync();

            var model = await dbContext.Orders.Where(o => o.ClientId == clientData.ClientId && o.IsBid).CountAsync();

            string userId = clientData.ApplicationUserId;
            string? clientAccountId = null;
            bool? isBid = true;
            bool? isNotActive = null;
            string? ISIN = null;
            string? searchTerm = null;
            OrderSorting sorting = OrderSorting.Newest;
            int currentPage = 1;
            int ordersPerPage = 1;

            var result = await orderService.AllAsyn(
                userId
                , clientAccountId
                , isBid
                , isNotActive
                , ISIN
                , searchTerm
                , sorting
                , currentPage
                , ordersPerPage);

            Assert.That(result.TotalOrdersCount, Is.EqualTo(model));
        }

        [Test]

        public async Task AllAsyn_WithSearchTermNonNull()
        {
            var clientData = await dbContext.DataOfIndividualClients.FirstAsync();

            var searchTermFinInstrName = await dbContext.FinancialInstruments.Select(x => x.Name).FirstAsync();

            var model = await dbContext.Orders.Where(o => o.ClientId == clientData.ClientId && o.FinancialInstrument.Name == searchTermFinInstrName).CountAsync();

            string userId = clientData.ApplicationUserId;
            string? clientAccountId = null;
            bool? isBid = null;
            bool? isNotActive = null;
            string? ISIN = null;
            string? searchTerm = searchTermFinInstrName;
            OrderSorting sorting = OrderSorting.Newest;
            int currentPage = 1;
            int ordersPerPage = 1;

            var result = await orderService.AllAsyn(
                userId
                , clientAccountId
                , isBid
                , isNotActive
                , ISIN
                , searchTerm
                , sorting
                , currentPage
                , ordersPerPage);

            Assert.That(result.TotalOrdersCount, Is.EqualTo(model));
        }

        [Test]

        public async Task GetBalanceByUserIdAsync_Correct()
        {
            var clientData = await dbContext.DataOfIndividualClients.FirstAsync();

            var model = await dbContext.Clients.Where(o => o.Id == clientData.ClientId).Select(x => x.Balance).FirstAsync();

            var result = await orderService.GetBalanceByUserIdAsync(clientData.ApplicationUserId);

            Assert.That(result, Is.EqualTo(model));
        }

        [Test]

        public void GetBalanceByUserIdAsync_UnauthoriseActionException()
        {
            Assert.ThrowsAsync<UnauthoriseActionException>(async ()=> await orderService.GetBalanceByUserIdAsync(new Guid().ToString()));
        }

        [Test]

        public async Task ExistOrderByIdAsync_Correct()
        {
            var orderId = await dbContext.Orders.Select(o => o.Id).FirstOrDefaultAsync();

            var result = await orderService.ExistOrderByIdAsync(orderId);

            Assert.IsTrue(result);
        }

        [Test]

        public async Task DeleteAllOredersByFinancialInstrumentAsync_Correct()
        {
            var clientData = await dbContext.DataOfIndividualClients.FirstAsync();
            var financialInstrumementId = await dbContext.Orders.Where(o => o.ClientId == clientData.ClientId && o.IsDeleted == false).Select(x => x.FinancialInstrumentId).FirstOrDefaultAsync();

            await orderService.DeleteAllOredersByFinancialInstrumentAsync(financialInstrumementId, clientData.ApplicationUserId);

            var model = await dbContext.Orders.Where(o => o.ClientId == clientData.ClientId && o.IsDeleted == false && o.FinancialInstrumentId == financialInstrumementId).CountAsync();

            Assert.AreEqual(0, model);
        }

        [Test]

        public void DeleteAllOredersByFinancialInstrumentAsync_UnauthoriseActionException()
        {
            Assert.ThrowsAsync<UnauthoriseActionException>(async () => await orderService.DeleteAllOredersByFinancialInstrumentAsync(1, new Guid().ToString()));
        }
    }
}
