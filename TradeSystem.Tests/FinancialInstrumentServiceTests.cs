using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Models.Enums;
using TradeSystem.Core.Models.FinacialInstrument;
using TradeSystem.Core.Services;
using TradeSystem.Data;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;
using TradeSystem.Data.Repositories;
using static TradeSystem.Common.ExceptionMessages;

namespace TradeSystem.Tests
{
    [TestFixture]

    public class FinancialInstrumentServiceTests
    {

        private DbContextOptions<TradeSystemDbContext> dbOptions;
        private TradeSystemDbContext dbContext;

        private IDeletableEntityRepository<Client> clientRepo;
        private IDeletableEntityRepository<Order> orderRepo;
        private IDeletableEntityRepository<ClientFinancialInstrument> clientFinInstrRepo;
        private IDeletableEntityRepository<FinancialInstrument> financialInstrumentRepo;
        private Mock<IClientService> mockClientService;

        [SetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TradeSystemDbContext>()
                .UseInMemoryDatabase("HouseRentingInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new TradeSystemDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            TradeSystem.Tests.SeedDatabase.DatabaseSeeder.SeedDatabase(this.dbContext);

            clientFinInstrRepo = new EfDeletableEntityRepository<ClientFinancialInstrument>(dbContext);
            clientRepo = new EfDeletableEntityRepository<Client>(dbContext);
            orderRepo = new EfDeletableEntityRepository<Order>(dbContext);
            financialInstrumentRepo = new EfDeletableEntityRepository<FinancialInstrument>(dbContext);

            mockClientService = new Mock<IClientService>();
        }

        [Test]

        public async Task CheckAllFinancialInstrumentsOfClientAsync_WithNullInput()
        {
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

        [Test]

        public async Task CheckAllFinancialInstrumentsOfClientAsync_WithCorectIdUser()
        {
            mockClientService.Setup(x => x.GetClientIdByUserIdAsync("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"))
                .ReturnsAsync(Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"));

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            var result = await financialInstrumentService.AllFinancialInstrumentsOfClientAsync("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            Assert.IsTrue(result.Count() == 4);
        }

        [Test]

        public async Task CreateAsyncWhitCorectData()
        {
            var model = new FinacialInstrumentFormModel()
            {
                ISIN = "BG11KAJMAT16",
                Name = "TK-PROPERTIES AD",
                Description = "6820 - Renting and operating of own or leased real estate"
            };

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            var result = await financialInstrumentService.CreateAsync(model);

            var modelId = dbContext.FinancialInstruments.Where(x => x.Name == model.Name).Select(x => x.Id).FirstOrDefault();

            Assert.That(result, Is.EqualTo(modelId));
        }

        [Test]

        public async Task CreateAsyncWhitDuplicateData()
        {
            var model = new FinacialInstrumentFormModel()
            {
                ISIN = "BG11KAJMAT16",
                Name = "TK-PROPERTIES AD",
                Description = "6820 - Renting and operating of own or leased real estate"
            };

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            await financialInstrumentService.CreateAsync(model);

            Assert.ThrowsAsync<NonExistFinancialInstrumentWithThisNameOrISIN>(async ()=> await financialInstrumentService.CreateAsync(model));
        }

        [Test]

        public async Task DeleteAsync_WithExistingModel()
        {
            
            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            await financialInstrumentService.DeleteAsync(4);

            var result = await dbContext.FinancialInstruments.FirstOrDefaultAsync(x => x.Id == 4 && x.IsDeleted == false);

            Assert.IsNull(result);
            Assert.That(dbContext.FinancialInstruments.Count(x => x.IsDeleted == false), Is.EqualTo(3));
        }

        [Test]

        public void DeleteAsync_WithNonExistingModel()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);
            
            var exeption = Assert.ThrowsAsync<Exception>(async () => await financialInstrumentService.DeleteAsync(5));
            Assert.That(dbContext.FinancialInstruments.Count(x => x.IsDeleted == false), Is.EqualTo(4));
            Assert.That(exeption.Message, Is.EqualTo(MessageNotDataException));
        }

        [Test]

        public async Task EditAsync_WithExistingModel()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            var modelDatabase = await dbContext.FinancialInstruments.FirstAsync(x => x.Id == 1);

            var modelToEdit = new FinacialInstrumentFormModel()
            {
                Name = "TestName",
                ISIN = modelDatabase.ISIN,
                Description = modelDatabase.Description,
            };

            await financialInstrumentService.EditAsyn(1, modelToEdit);
            var result = await dbContext.FinancialInstruments.FirstAsync(x => x.Id == 1);

            Assert.That(result.Name, Is.EqualTo(modelToEdit.Name));
        }

        [Test]

        public async Task EditAsync_WithNonExistingModel()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            var modelDatabase = await dbContext.FinancialInstruments.FirstAsync(x => x.Id == 1);

            var modelToEdit = new FinacialInstrumentFormModel()
            {
                Name = "TestName",
                ISIN = modelDatabase.ISIN,
                Description = modelDatabase.Description,
            };

            var exeption = Assert.ThrowsAsync<Exception>(async () => await financialInstrumentService.EditAsyn(6, modelToEdit));
            Assert.That(exeption.Message, Is.EqualTo(MessageNotDataException));
        }

        [Test]

        public async Task ExixtFinancialInstrumentAsync_WithNonExistingModel()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            var result = await financialInstrumentService.ExixtFinancialInstrumentAsync(6);
                        
            Assert.IsFalse(result);
        }

        [Test]

        public async Task ExixtFinancialInstrumentAsync_WithExistingModel()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            var result = await financialInstrumentService.ExixtFinancialInstrumentAsync(1);

            Assert.IsTrue(result);
        }

        [Test]

        public async Task GetFinInstrumentDetailsByIdAsync_WithExistingModel()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            var modelDatabase = await dbContext.FinancialInstruments.FirstAsync(x => x.Id == 1);


            var result = await financialInstrumentService.GetFinInstrumentDetailsByIdAsync(1);

            Assert.That(result.Name, Is.EqualTo(modelDatabase.Name));
        }

        [Test]

        public void GetFinInstrumentDetailsByIdAsync_WithNonExistingModel()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            var exeption = Assert.ThrowsAsync<Exception>(async () => await financialInstrumentService.GetFinInstrumentDetailsByIdAsync(6));
            Assert.That(exeption.Message, Is.EqualTo(MessageNotDataException));
        }

        [Test]

        public async Task GetEditAsync_WithExistingModel()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            var modelDatabase = await dbContext.FinancialInstruments.FirstAsync(x => x.Id == 1);

            var result = await financialInstrumentService.GetEditAsync(1);


            Assert.That(result.Name, Is.EqualTo(modelDatabase.Name));
        }

        [Test]

        public void GetEditAsync_WithNonExistingModel()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);
                        
            var exeption = Assert.ThrowsAsync<Exception>(async () => await financialInstrumentService.GetEditAsync(6));
            Assert.That(exeption.Message, Is.EqualTo(MessageNotDataException));
        }

        [Test]

        public async Task GetFinancialInstrumentByIdAsync_WithExistingModel()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            var modelDatabase = await dbContext.FinancialInstruments.FirstAsync(x => x.Id == 1);

            var result = await financialInstrumentService.GetFinancialInstrumentByIdAsync(1);


            Assert.That(result.Name, Is.EqualTo(modelDatabase.Name));
        }

        [Test]

        public async Task GetFinancialInstrumentByIdAsync_WithNonExistingModel()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            var result = await financialInstrumentService.GetFinancialInstrumentByIdAsync(6);

            Assert.IsNull(result);
        }

        [Test]

        public async Task AllAsyn_WithAllChechingNull()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);


            string? ISIN = null;
            string? searchTerm = null;
            var sorting = FinInstrumentsSorting.Newest;
            int currentPage = 1;
            int finInstrumentsPerPage = 1;

            var result = await financialInstrumentService.AllAsyn(ISIN, searchTerm, sorting, currentPage, finInstrumentsPerPage);


            Assert.That(result.TotalFinInstrumentCount, Is.EqualTo(4));
        }

        [Test]

        public async Task AllAsyn_WithAllChechingISINNotNull()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);


            string? ISIN = "BG1100003166";
            string? searchTerm = null;
            var sorting = FinInstrumentsSorting.Sharesholders;
            int currentPage = 1;
            int finInstrumentsPerPage = 1;

            var result = await financialInstrumentService.AllAsyn(ISIN, searchTerm, sorting, currentPage, finInstrumentsPerPage);


            Assert.That(result.TotalFinInstrumentCount, Is.EqualTo(1));
        }

        [Test]

        public async Task AllAsyn_WithAllChechingSerchTermNotNull()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);


            string? ISIN = null;
            string? searchTerm = "SHELLY GROUP";
            var sorting = FinInstrumentsSorting.Name;
            int currentPage = 1;
            int finInstrumentsPerPage = 1;

            var result = await financialInstrumentService.AllAsyn(ISIN, searchTerm, sorting, currentPage, finInstrumentsPerPage);


            Assert.That(result.TotalFinInstrumentCount, Is.EqualTo(1));
        }

        [Test]

        public async Task AllISINsAsynCorect()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);            

            var result = await financialInstrumentService.AllISINsAsync();


            Assert.That(result.Count(), Is.EqualTo(4));
        }

        [Test]

        public void FundedAccountWithFinancialInstruments_ClientNonExisten()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            Assert.ThrowsAsync<Exception>(async () => await financialInstrumentService.FundedAccountWithFinancialInstruments(Guid.Parse("98807339-c1a5-4c2e-81f2-7c15e493bec8"), 1, 100));
        }

        [Test]

        public async Task FundedAccountWithFinancialInstruments_FinancialInstrumentNonExisten()
        {
            var clentId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca");

           Client Individual = await dbContext.Clients.FirstAsync(x => x.Id == clentId);

            mockClientService.Setup(c => c.GetClientByClientIdAcync(clentId))
                .ReturnsAsync(Individual);

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            Assert.ThrowsAsync<NonFinancialInstrumentException>(async () => await financialInstrumentService.FundedAccountWithFinancialInstruments(clentId, 5, 100));
        }

        [Test]

        public async Task FundedAccountWithFinancialInstruments_IncreasesExitsFinancialInstrument()
        {
            var clientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca");

            Client Individual = await dbContext.Clients.FirstAsync(x => x.Id == clientId);

            mockClientService.Setup(c => c.GetClientByClientIdAcync(clientId))
                .ReturnsAsync(Individual);

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            await financialInstrumentService.FundedAccountWithFinancialInstruments(clientId, 1, 100);

            var result = await dbContext.ClientFinancialInstruments.Where(x => x.FinancialInstrumentId == 1 && x.ClientId == clientId).Select(x => (int)x.Volume).SumAsync();

            Assert.That(result, Is.EqualTo(5100));
        }

        [Test]

        public async Task FundedAccountWithFinancialInstruments_IncreasesNonExitsFinancialInstrument()
        {
            var clientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18");

            Client Individual = await dbContext.Clients.FirstAsync(x => x.Id == clientId);

            mockClientService.Setup(c => c.GetClientByClientIdAcync(clientId))
                .ReturnsAsync(Individual);

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            await financialInstrumentService.FundedAccountWithFinancialInstruments(clientId, 1, 100);

            var result = await dbContext.ClientFinancialInstruments.Where(x => x.FinancialInstrumentId == 1 && x.ClientId == clientId).Select(x => (int)x.Volume).SumAsync();

            Assert.That(result, Is.EqualTo(100));
        }

        [Test]

        public async Task AllFinancialInstrumentsAsync_Corect()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            var result = await financialInstrumentService.AllFinancialInstrumentsAsync();

            Assert.That(result.Count(), Is.EqualTo(4));
        }

        [Test]

        public async Task GetCountOfOwnerFinancialInstrumentOnClientByIdAsync_Corect()
        {

            var financialInstrumentService = new FinancialInstrumentService(
                                                                                orderRepo
                                                                                , clientFinInstrRepo
                                                                                , financialInstrumentRepo
                                                                                , mockClientService.Object);

            var result = await financialInstrumentService.GetCountOfOwnerFinancialInstrumentOnClientByIdAsync(Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"), 2);

            Assert.That(result, Is.EqualTo(6000));
        }
    }
}
