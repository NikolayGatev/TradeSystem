using Microsoft.EntityFrameworkCore;
using Moq;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Services;
using TradeSystem.Data;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;
using TradeSystem.Data.Repositories;

namespace TradeSystem.Tests
{
    [TestFixture]

    public class FinancialInstrumentServiceTests
    {

        private DbContextOptions<TradeSystemDbContext> dbOptions;
        private TradeSystemDbContext dbContext;
        private IClientService clientService;

        protected IDeletableEntityRepository<Client> clientRepo;
        protected IDeletableEntityRepository<Order> orderRepo;
        protected IDeletableEntityRepository<ClientFinancialInstrument> clientFinInstrRepo;
        protected IDeletableEntityRepository<FinancialInstrument> financialInstrumentRepo; 
        protected Mock<IClientService> mockClientService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TradeSystemDbContext>()
                .UseInMemoryDatabase("HouseRentingInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new TradeSystemDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            TradeSystem.Tests.SeedDatabase.DatabaseSeeder.SeedDatabase(this.dbContext);
        }

        [Test]

        public async Task CheckAllFinancialInstrumentsOfClientAsync()
        {
            clientFinInstrRepo = new EfDeletableEntityRepository<ClientFinancialInstrument>(dbContext);
            clientRepo = new EfDeletableEntityRepository<Client>(dbContext);
            orderRepo = new EfDeletableEntityRepository<Order>(dbContext);
            financialInstrumentRepo = new EfDeletableEntityRepository<FinancialInstrument>(dbContext);

            mockClientService = new Mock<IClientService>();
            mockClientService.Setup(x => x.GetClientIdByUserIdAsync(new Guid().ToString()))
                .ReturnsAsync(new Guid());

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            var result = await financialInstrumentService.AllFinancialInstrumentsOfClientAsync(null);

            Assert.IsTrue(result.Count() == 4);


        }
    }
}
