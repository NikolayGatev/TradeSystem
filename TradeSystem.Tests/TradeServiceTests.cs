using Microsoft.EntityFrameworkCore;
using Moq;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Services;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;
using TradeSystem.Data.Repositories;
using TradeSystem.Data;
using TradeSystem.Core.Models.Enums;
using TradeSystem.Core.Exeptions;

namespace TradeSystem.Tests
{
    [TestFixture]

    public class TradeServiceTests
    {
        private DbContextOptions<TradeSystemDbContext> dbOptions;
        private TradeSystemDbContext dbContext;

        private IDeletableEntityRepository<Trade> tradeRepozitory;
        private IDeletableEntityRepository<TradeOrder> tradeOrderRepozitory;
        private Mock<IClientService> mockClientService;
        private Mock<IEmployeeService> mockEmployeeService;

        private ITradeService tradeService;

        [SetUp]
        public async Task OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TradeSystemDbContext>()
                .UseInMemoryDatabase("HouseRentingInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new TradeSystemDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            TradeSystem.Tests.SeedDatabase.DatabaseSeeder.SeedDatabase(this.dbContext);

            tradeRepozitory = new EfDeletableEntityRepository<Trade>(dbContext);
            tradeOrderRepozitory = new EfDeletableEntityRepository<TradeOrder>(dbContext);

            mockClientService = new Mock<IClientService>();
            var client = await dbContext.Clients.FirstAsync();

            mockClientService.Setup(x => x.ExistClientByIdAsync(client.Id))
                    .ReturnsAsync(true);
            mockClientService.Setup(x => x.GetClientIdByUserIdAsync("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"))
                    .ReturnsAsync(client.Id);

            mockEmployeeService = new Mock<IEmployeeService>();

            var employeeUsserId = await dbContext.Employees.Select(e => e.ApplicationUserId).FirstAsync();
            mockEmployeeService.Setup(x => x.ExistsByUserIdAsync(new Guid().ToString()))
                .ReturnsAsync(false);
            mockEmployeeService.Setup(x => x.ExistsByUserIdAsync(employeeUsserId))
                .ReturnsAsync(true);

            tradeService = new TradeService(
                tradeRepozitory
                , tradeOrderRepozitory
                , mockClientService.Object
                , mockEmployeeService.Object);
        }

        [Test]

        public async Task AllAsyn_WithAllChechingNull()
        {
            var clientData = await dbContext.DataOfIndividualClients.FirstAsync();

            var model = await dbContext.Trades.Where(o => o.TradeOrders.Any(to => to.Order.ClientId == clientData.ClientId)).CountAsync();

            string userId = clientData.ApplicationUserId;
            string? clientAccountId = null;
            bool? isBid = null;
            string? ISIN = null;
            string? searchTerm = null;
            TradeSorting sorting = TradeSorting.Newest;
            int currentPage = 1;
            int ordersPerPage = 1;

            var result = await tradeService.AllAsyn(
                userId
                , clientAccountId
                , isBid
                , ISIN
                , searchTerm
                , sorting
                , currentPage
                , ordersPerPage);

            Assert.That(result.TotalTradesCount, Is.EqualTo(model));
        }

        [Test]

        public async Task AllAsyn_WithISINNonNull()
        {
            var isin = await dbContext.FinancialInstruments.Select(f => f.ISIN).FirstAsync();

            var clientData = await dbContext.DataOfIndividualClients.FirstAsync();

            var model = await dbContext.Trades.Where(o => o.TradeOrders.Any(to => to.Order.ClientId == clientData.ClientId) && o.FinancialInstrument.ISIN == isin).CountAsync();

            string userId = clientData.ApplicationUserId;
            string? clientAccountId = null;
            bool? isBid = null;
            string? ISIN = isin;
            string? searchTerm = null;
            TradeSorting sorting = TradeSorting.Newest;
            int currentPage = 1;
            int ordersPerPage = 1;

            var result = await tradeService.AllAsyn(
                userId
                , clientAccountId
                , isBid
                , ISIN
                , searchTerm
                , sorting
                , currentPage
                , ordersPerPage);

            Assert.That(result.TotalTradesCount, Is.EqualTo(model));
        }

        [Test]

        public async Task AllAsyn_WithClientAcountNonNull()
        {
            var clientData = await dbContext.DataOfIndividualClients.FirstAsync();

            var model = await dbContext.Trades.Where(o => o.TradeOrders.Any(to => to.Order.ClientId == clientData.ClientId && to.Order.ClientId == clientData.ClientId)).CountAsync();

            string userId = clientData.ApplicationUserId;
            string? clientAccountId = clientData.ClientId.ToString();
            bool? isBid = null;
            string? ISIN = null;
            string? searchTerm = null;
            TradeSorting sorting = TradeSorting.Newest;
            int currentPage = 1;
            int ordersPerPage = 1;

            var result = await tradeService.AllAsyn(
                userId
                , clientAccountId
                , isBid
                , ISIN
                , searchTerm
                , sorting
                , currentPage
                , ordersPerPage);

            Assert.That(result.TotalTradesCount, Is.EqualTo(model));
        }

        [Test]

        public async Task AllAsyn_WithIsBidNonNull()
        {
            var clientData = await dbContext.DataOfIndividualClients.FirstAsync();

            var model = await dbContext.Trades.Where(o => o.TradeOrders.Any(to => to.Order.ClientId == clientData.ClientId && to.Order.IsBid)).CountAsync();

            string userId = clientData.ApplicationUserId;
            string? clientAccountId = clientData.ClientId.ToString(); 
            bool? isBid = true;
            string? ISIN = null;
            string? searchTerm = null;
            TradeSorting sorting = TradeSorting.Newest;
            int currentPage = 1;
            int ordersPerPage = 1;

            var result = await tradeService.AllAsyn(
                userId
                , clientAccountId
                , isBid
                , ISIN
                , searchTerm
                , sorting
                , currentPage
                , ordersPerPage);

            Assert.That(result.TotalTradesCount, Is.EqualTo(model));
        }

        [Test]

        public async Task AllAsyn_WithSearchTermNonNull()
        {
            var financialInstrumentName = await dbContext.FinancialInstruments.Select(f => f.Name).FirstAsync();

            var clientData = await dbContext.DataOfIndividualClients.FirstAsync();

            var model = await dbContext.Trades.Where(o => o.TradeOrders.Any(to => to.Order.ClientId == clientData.ClientId) && o.FinancialInstrument.Name == financialInstrumentName).CountAsync();

            string userId = clientData.ApplicationUserId;
            string? clientAccountId = null;
            bool? isBid = null;
            string? ISIN = null;
            string? searchTerm = financialInstrumentName;
            TradeSorting sorting = TradeSorting.Newest;
            int currentPage = 1;
            int ordersPerPage = 1;

            var result = await tradeService.AllAsyn(
                userId
                , clientAccountId
                , isBid
                , ISIN
                , searchTerm
                , sorting
                , currentPage
                , ordersPerPage);

            Assert.That(result.TotalTradesCount, Is.EqualTo(model));
        }

        [Test]

        public void AllAsyn_UnauthoriseActionException()
        {
            string userId = new Guid().ToString();
            string? clientAccountId = null;
            bool? isBid = null;
            string? ISIN = null;
            string? searchTerm = null;
            TradeSorting sorting = TradeSorting.Newest;
            int currentPage = 1;
            int ordersPerPage = 1;

            Assert.ThrowsAsync< UnauthoriseActionException>(async ()=> await tradeService.AllAsyn(
                userId
                , clientAccountId
                , isBid
                , ISIN
                , searchTerm
                , sorting
                , currentPage
                , ordersPerPage));
        }

        [Test]

        public void DeleteAllOredersByFinancialInstrumentAsync_UnauthoriseActionException()
        {
            Assert.ThrowsAsync<UnauthoriseActionException>(async () => await tradeService.DeleteAsync(new Guid(), new Guid().ToString()));
        }

        [Test]

        public async Task GetOrdersOfTradeByIdAsync_Corect()
        {
            var tradeId = await dbContext.Trades.Where(t => t.IsDeleted == false).Select(t => t.Id).FirstAsync();

            var model = await dbContext.TradeOrders.Where(to => to.Trade.Id == tradeId).CountAsync();

            var result = await tradeService.GetOrdersOfTradeByIdAsync(tradeId);

            Assert.That(result.Count, Is.EqualTo(model));
        }

        [Test]

        public async Task GetTradeDetailsByIdAsync_Corect()
        {
            var trade = await dbContext.Trades.Where(t => t.IsDeleted == false).FirstAsync();

            var employeeUsserId = await dbContext.Employees.Select(e => e.ApplicationUserId).FirstAsync();

            var result = await tradeService.GetTradeDetailsByIdAsync(trade.Id, employeeUsserId);

            Assert.That(result.Id, Is.EqualTo(trade.Id));
        }

        [Test]

        public void GetTradeDetailsByIdAsync_UnauthoriseActionException()
        {
            Assert.ThrowsAsync<UnauthoriseActionException>(async () => await tradeService.GetTradeDetailsByIdAsync(new Guid(), new Guid().ToString()));
        }

        [Test]

        public async Task GetTradeByIdAsync_Corect()
        {
            var trade = await dbContext.Trades.Where(t => t.IsDeleted == false).FirstAsync();

            var result = await tradeService.GetTradeByIdAsync(trade.Id);

            Assert.That(result.Id, Is.EqualTo(trade.Id));
        }

        [Test]

        public async Task RealTimeTrdeAcync_Corect()
        {
            var model = await dbContext.Trades.Where(t => t.IsDeleted == false).GroupBy(t => t.FinancialInstrument.ISIN).Select(t => t.First()).ToListAsync();

            var result = await tradeService.RealTimeTrdeAcync();

            Assert.That(result.Count, Is.EqualTo(model.Count));
        }
    }
}
