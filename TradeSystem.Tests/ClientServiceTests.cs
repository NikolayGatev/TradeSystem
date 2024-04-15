using Microsoft.EntityFrameworkCore;
using Moq;
using TradeSystem.Core.Contracts;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;
using TradeSystem.Data.Repositories;
using TradeSystem.Data;
using static TradeSystem.Common.ExceptionMessages;
using TradeSystem.Core.Services;
using TradeSystem.Core.Models.Clients;
using Microsoft.Extensions.Logging;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Models.Enums;

namespace TradeSystem.Tests
{
    [TestFixture]

    public class ClientServiceTests
    {
        private DbContextOptions<TradeSystemDbContext> dbOptions;
        private TradeSystemDbContext dbContext;

        private IDeletableEntityRepository<Employee> employeeRepo;
        private IDeletableEntityRepository<Client> clientRepo;
        private IDeletableEntityRepository<Country> countryRepo;
        private IRepository<DataOfCorporateveClient> dataCorporativeClientRepo;
        private IRepository<DataOfIndividualClient> dataIndividualClientRepo;
        private IDeletableEntityRepository<Order> orderRepo;
        private IDeletableEntityRepository<Town> townRepo;

        private IClientService clientService;

        [SetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TradeSystemDbContext>()
                .UseInMemoryDatabase("HouseRentingInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new TradeSystemDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            TradeSystem.Tests.SeedDatabase.DatabaseSeeder.SeedDatabase(this.dbContext);

            employeeRepo = new EfDeletableEntityRepository<Employee>(dbContext);
            clientRepo = new EfDeletableEntityRepository<Client>(dbContext);
            countryRepo = new EfDeletableEntityRepository<Country>(dbContext);
            dataCorporativeClientRepo = new EfRepository<DataOfCorporateveClient>(dbContext);
            dataIndividualClientRepo = new EfRepository<DataOfIndividualClient>(dbContext);
            orderRepo = new EfDeletableEntityRepository<Order>(dbContext);
            townRepo = new EfDeletableEntityRepository<Town>(dbContext);

            clientService = new ClientService(
                employeeRepo
                ,clientRepo
                ,countryRepo
                ,dataCorporativeClientRepo
                ,dataIndividualClientRepo
                ,orderRepo
                ,townRepo);
        }

        [Test]

        public async Task AllClientsAsync_Corect()
        {
            var result = await clientService.AllClientsAsync();

            Assert.IsTrue(result.Count() == 2);
        }

        [Test]

        public async Task AllCountriesAsync_Corect()
        {
            var result = await clientService.AllCountriesAsync();

            Assert.IsTrue(result.Count() == 3);
        }

        [Test]

        public async Task CountryExistsAsync_Corect()
        {
            var result = await clientService.CountryExistsAsync(1);

            Assert.IsTrue(result);
        }

        [Test]

        public async Task CreateDataOfCorporativeClientAsync_FileIsNull()
        {
            var model = new CorporativeDataClentFormModel()
            {
                NationalityId = 1,
                Address = "Sveta Troica, blok 143",
                Town = "Sofiq",
                PhoneNumber = "1234567890",
                NationalIdentityNumber = "1234567890",
                Name = "TestCompany",
                LegalForm = "EOOD",
                NameOfRepresentative = "Petko Mitev"
            };

            var result = await clientService.CreateDataOfCorporativeClientAsync(model, "4a6e690e-7d13-4c7e-88e9-8d7f10f456bb");

            Assert.IsNotNull(result);
        }

        [Test]

        public async Task CreateDataOfIndividualClientAsync_FileIsNull()
        {
            var model = new IndividualDataClentFormModel()
            {
                NationalityId = 1,
                Address = "Sveta Troica, blok 143",
                Town = "Sofiq",
                PhoneNumber = "1234567890",
                NationalIdentityNumber = "1234567890",
                FirstName = "Mitko",
                Surname = "Valkanov",
                DateOfBirth = "1.1.2002"
            };

            var result = await clientService.CreateDataOfIndividualClientAsync(model, "4a6e690e-7d13-4c7e-88e9-8d7f10f456bb");

            Assert.IsNotNull(result);
        }

        [Test]

        public async Task DeleteAsync_CorectCorporativeData()
        {
            var countPreviewOperation = await dbContext.DataOfCorporateClients.CountAsync();

            await clientService.DeleteAsync(Guid.Parse("3c2a6e70-1466-482c-8908-21f1ea3b5eb4"));

            var countNextOperation = await dbContext.DataOfCorporateClients.CountAsync();

            Assert.IsFalse(countPreviewOperation == countNextOperation);
        }

        [Test]

        public async Task DeleteAsync_CorectIndividualData()
        {
            var countPreviewOperation = await dbContext.DataOfIndividualClients.CountAsync();

            await clientService.DeleteAsync(Guid.Parse("f316a20f-0bfa-4412-81a1-50bcb6562bc0"));

            var countNextOperation = await dbContext.DataOfIndividualClients.CountAsync();

            Assert.IsFalse(countPreviewOperation == countNextOperation);
        }

        [Test]

        public async Task DeleteAsync_InCorectIdData()
        {
            Assert.ThrowsAsync<NonDataOfClientException>(async () => await clientService.DeleteAsync(Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18")));           
        }

        [Test]

        public async Task DetailsOfAcountOnClientAsync_WithExistingModel()
        {
            var dataOfClient = await dbContext.DataOfCorporateClients.FirstAsync();
            var modelDatabase = await dbContext.Clients.FirstOrDefaultAsync(x => x.Id == dataOfClient.ClientId);


            var result = await clientService.DetailsOfAcountOnClientAsync(dataOfClient.ApplicationUserId);

            Assert.That(result.Balance, Is.EqualTo(modelDatabase.Balance));
        }

        [Test]

        public async Task GetFinInstrumentDetailsByIdAsync_WithNonExistingModel()
        {
            var exeption = Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await clientService.DetailsOfAcountOnClientAsync("98807339-c1a5-4c2e-81f2-7c15e493bec8"));
            Assert.That(exeption.Message, Is.EqualTo(MessageUnauthoriseActionException));
        }

        [Test]

        public async Task DetailsOfDataOnClientAsync_CorectCorporativeData()
        {
            var dataOfClient = await dbContext.DataOfCorporateClients.FirstAsync();

            var model = await clientService.DetailsOfDataOnClientAsync(dataOfClient.ApplicationUserId);

            Assert.That(dataOfClient.Id, Is.EqualTo(model.Id));
        }

        [Test]

        public async Task DetailsOfDataOnClientAsync_CorectIndividualData()
        {
            var dataOfClient = await dbContext.DataOfIndividualClients.FirstAsync();

            var model = await clientService.DetailsOfDataOnClientAsync(dataOfClient.ApplicationUserId);

            Assert.That(dataOfClient.Id, Is.EqualTo(model.Id));
        }

        [Test]

        public async Task DetailsOfDataOnClientAsync_Exception()
        {
            var exeption = Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await clientService.DetailsOfDataOnClientAsync("98807339-c1a5-4c2e-81f2-7c15e493bec8"));
            Assert.That(exeption.Message, Is.EqualTo(MessageUnauthoriseActionException));
        }

        [Test]

        public async Task EditDataOfCorporativeClientAsync_Successfully()
        {
            var dataOfClient = await dbContext.DataOfCorporateClients.FirstAsync();

            var changeData = new CorporativeDataClentFormModel()
            {
                Name = "TestException",
                Address = dataOfClient.Address,
                LegalForm = dataOfClient.LegalForm,
                NameOfRepresentative = dataOfClient.NameOfRepresentative,
                NationalityId = dataOfClient.NationalityId,
                Town = dataOfClient.Town.Name,
                PhoneNumber = dataOfClient.PhoneNumber,
                NationalIdentityNumber = dataOfClient.NationalIdentityNumber,
            };

            await clientService.EditDataOfCorporativeClientAsync(dataOfClient.Id, changeData);

            var dataOfClientChange = await dbContext.DataOfCorporateClients.FirstAsync();

            Assert.That(dataOfClient.Name, Is.EqualTo(dataOfClientChange.Name));
        }

        [Test]

        public async Task EditDataOfCorporativeClientAsync_Exception()
        {
            var dataOfClient = await dbContext.DataOfCorporateClients.FirstAsync();

            var changeData = new CorporativeDataClentFormModel()
            {
                Name = "TestException",
                Address = dataOfClient.Address,
                LegalForm = dataOfClient.LegalForm,
                NameOfRepresentative = dataOfClient.NameOfRepresentative,
                NationalityId = dataOfClient.NationalityId,
                Town = dataOfClient.Town.Name,
                PhoneNumber = dataOfClient.PhoneNumber,
                NationalIdentityNumber = dataOfClient.NationalIdentityNumber,
            };

            var exeption = Assert.ThrowsAsync<NonDataOfClientException>(async () => await clientService.EditDataOfCorporativeClientAsync(new Guid(), changeData));
            Assert.That(exeption.Message, Is.EqualTo(MessageNotDataException));
        }


        [Test]

        public async Task EditDataOfIndividualClientAsync_Successfully()
        {
            var dataOfClient = await dbContext.DataOfIndividualClients.FirstAsync();

            var changeData = new IndividualDataClentFormModel()
            {
                FirstName = "TestException",
                Address = dataOfClient.Address,
                Surname = dataOfClient.Surname,
                DateOfBirth = "1.1.2002",
                NationalityId = dataOfClient.NationalityId,
                Town = dataOfClient.Town.Name,
                PhoneNumber = dataOfClient.PhoneNumber,
                NationalIdentityNumber = dataOfClient.NationalIdentityNumber,
            };

            await clientService.EditDataOfIndividualClientAsync(dataOfClient.Id, changeData);

            var dataOfClientChange = await dbContext.DataOfIndividualClients.FirstAsync();

            Assert.That(dataOfClient.FirstName, Is.EqualTo(dataOfClientChange.FirstName));
        }

        [Test]

        public async Task EditDataOfIndividualClientAsync_Exception()
        {
            var dataOfClient = await dbContext.DataOfIndividualClients.FirstAsync();

            var changeData = new IndividualDataClentFormModel()
            {
                FirstName = "TestException",
                Address = dataOfClient.Address,
                Surname = dataOfClient.Surname,
                DateOfBirth = "1.1.2002",
                NationalityId = dataOfClient.NationalityId,
                Town = dataOfClient.Town.Name,
                PhoneNumber = dataOfClient.PhoneNumber,
                NationalIdentityNumber = dataOfClient.NationalIdentityNumber,
            };

            var exeption = Assert.ThrowsAsync<NonDataOfClientException>(async () => await clientService.EditDataOfIndividualClientAsync(new Guid(), changeData));
            Assert.That(exeption.Message, Is.EqualTo(MessageNotDataException));
        }


        [Test]

        public async Task ExistClientByIdAsync_True()
        {
            var dataOfClient = await dbContext.DataOfCorporateClients.FirstAsync();

            var result = await clientService.ExistClientByIdAsync(dataOfClient.ClientId ?? new Guid());

            Assert.IsTrue(result);
        }

        [Test]

        public async Task ExistClientByUserIdAsync_TrueCorporative()
        {
            var dataOfClient = await dbContext.DataOfCorporateClients.FirstAsync();

            var result = await clientService.ExistClientByUserIdAsync(dataOfClient.ApplicationUserId);

            Assert.IsTrue(result);
        }

        [Test]

        public async Task ExistClientByUserIdAsync_TrueIndividual()
        {
            var dataOfClient = await dbContext.DataOfIndividualClients.FirstAsync();

            var result = await clientService.ExistClientByUserIdAsync(dataOfClient.ApplicationUserId);

            Assert.IsTrue(result);
        }

        [Test]

        public async Task ExistClientByUserIdAsync_False()
        {
            var dataOfClient = await dbContext.DataOfIndividualClients.FirstAsync();

            var result = await clientService.ExistClientByUserIdAsync(dataOfClient.Id.ToString());

            Assert.IsFalse(result);
        }

        [Test]

        public async Task GetClientIdByUserIdAsync_CorectIndividual()
        {
            var dataOfClient = await dbContext.DataOfIndividualClients.FirstAsync();

            var result = await clientService.GetClientIdByUserIdAsync(dataOfClient.ApplicationUserId);

            Assert.That(result, Is.EqualTo(dataOfClient.ClientId));
        }

        [Test]

        public async Task GetDataOfCorporativeClientFormByIdAsync_Corporative()
        {
            var dataOfClient = await dbContext.DataOfCorporateClients.FirstAsync();

            var result = await clientService.GetDataOfCorporativeClientFormByIdAsync(dataOfClient.Id);

            Assert.That(result.NationalIdentityNumber, Is.EqualTo(dataOfClient.NationalIdentityNumber));
        }

        [Test]

        public async Task GetDataOfCorporativeClientFormByIdAsync_Exception()
        {
            var exception = Assert.ThrowsAsync<NonDataOfClientException>(async () => await clientService.GetDataOfCorporativeClientFormByIdAsync(new Guid()));
            Assert.That(exception.Message, Is.EqualTo(MessageNotDataException));
        }

        [Test]

        public async Task GetDataOfIdividualClientFormByIdAsync_Corporative()
        {
            var dataOfClient = await dbContext.DataOfIndividualClients.FirstAsync();

            var result = await clientService.GetDataOfIdividualClientFormByIdAsync(dataOfClient.Id);

            Assert.That(result.NationalIdentityNumber, Is.EqualTo(dataOfClient.NationalIdentityNumber));
        }

        [Test]

        public async Task GetDataOfIdividualClientFormByIdAsync_Exception()
        {
            var exception = Assert.ThrowsAsync<NonDataOfClientException>(async () => await clientService.GetDataOfIdividualClientFormByIdAsync(new Guid()));
            Assert.That(exception.Message, Is.EqualTo(MessageNotDataException));
        }

        [Test]

        public async Task AllClientsDataAsync_WithAllChechingNull()
        {
            string? nationality = null;
            string? status = null;
            string? searchTerm = null;
            string? typeOfClient = null;
            int currentPage = 1;
            int datasPerPage = 1;

            var result = await clientService.AllClientsDataAsync(nationality, status, searchTerm, typeOfClient, currentPage, datasPerPage);


            Assert.That(result.TotalClientsDataCount, Is.EqualTo(2));
        }

        [Test]

        public async Task AllClientsDataAsync_WithStatusNotNull()
        {
            string? nationality = null;
            string? status = "NotChecking";
            string? searchTerm = null;
            string? typeOfClient = null;
            int currentPage = 1;
            int datasPerPage = 1;

            var result = await clientService.AllClientsDataAsync(nationality, status, searchTerm, typeOfClient, currentPage, datasPerPage);


            Assert.That(result.TotalClientsDataCount, Is.EqualTo(0));
        }

        [Test]

        public async Task AllClientsDataAsync_WithNationalityNotNull()
        {
            string? nationality = "Bulgaria";
            string? status = null;
            string? searchTerm = null;
            string? typeOfClient = null;
            int currentPage = 1;
            int datasPerPage = 1;

            var result = await clientService.AllClientsDataAsync(nationality, status, searchTerm, typeOfClient, currentPage, datasPerPage);


            Assert.That(result.TotalClientsDataCount, Is.EqualTo(2));
        }

        [Test]

        public async Task AllClientsDataAsync_WithSearchTermNotNull()
        {
            string? nationality = null;
            string? status = null;
            string? searchTerm = "1234456";
            string? typeOfClient = null;
            int currentPage = 1;
            int datasPerPage = 1;

            var result = await clientService.AllClientsDataAsync(nationality, status, searchTerm, typeOfClient, currentPage, datasPerPage);


            Assert.That(result.TotalClientsDataCount, Is.EqualTo(1));
        }

        [Test]

        public async Task AllClientsDataAsync_WithTypeOfClientIndividualNotNull()
        {
            string? nationality = null;
            string? status = null;
            string? searchTerm = null;
            string? typeOfClient = "IndividualClient";
            int currentPage = 1;
            int datasPerPage = 1;

            var result = await clientService.AllClientsDataAsync(nationality, status, searchTerm, typeOfClient, currentPage, datasPerPage);


            Assert.That(result.TotalClientsDataCount, Is.EqualTo(1));
        }

        [Test]

        public async Task AllClientsDataAsync_WithTypeOfClientCorporativeNotNull()
        {
            string? nationality = null;
            string? status = null;
            string? searchTerm = null;
            string? typeOfClient = "CorporativeClient";
            int currentPage = 1;
            int datasPerPage = 1;

            var result = await clientService.AllClientsDataAsync(nationality, status, searchTerm, typeOfClient, currentPage, datasPerPage);


            Assert.That(result.TotalClientsDataCount, Is.EqualTo(1));
        }

        [Test]

        public async Task AddMoneyAsync_Corect()
        {
            var dataOfClient = await dbContext.DataOfIndividualClients.FirstAsync();

            var clientBalancePreviewOperation = (await clientService.GetClientByClientIdAcync(dataOfClient.ClientId ?? new Guid())).Balance;

            await clientService.AddMoneyAsync(dataOfClient.ApplicationUserId, 1000);

            var clientNextOperation = await clientService.GetClientByClientIdAcync(dataOfClient.ClientId ?? new Guid());

            Assert.That(clientBalancePreviewOperation + 1000, Is.EqualTo(clientNextOperation.Balance));
        }

        [Test]

        public async Task AddMoneyAsync_UnauthoriseActionException()
        {
            var exception = Assert.ThrowsAsync<UnauthoriseActionException>(async () => await clientService.AddMoneyAsync(new Guid().ToString(), 1000));
            Assert.That(exception.Message, Is.EqualTo(MessageUnauthoriseActionException));
        }

        [Test]

        public async Task AddMoneyAsync_Exception()
        {
            var dataOfClient = await dbContext.DataOfIndividualClients.FirstAsync();

            var exception = Assert.ThrowsAsync<Exception>(async () => await clientService.AddMoneyAsync(dataOfClient.ApplicationUserId, -1000));
            Assert.That(exception.Message, Is.EqualTo(MessageNegativeSum));
        }

        [Test]

        public async Task GetClintDetailsAsync_Corect()
        {
            var dataOfClient = await dbContext.DataOfIndividualClients.FirstAsync();

            var client = await clientService.GetClientByClientIdAcync(dataOfClient.ClientId ?? new Guid());

            var result = await clientService.GetClintDetailsAsync(dataOfClient.ApplicationUserId);

            Assert.That(client.Id, Is.EqualTo(result.Id));
        }

        [Test]

        public async Task GetClintDetailsAsync_UnauthoriseActionException()
        {
            var exception = Assert.ThrowsAsync<UnauthoriseActionException>(async () => await clientService.GetClintDetailsAsync(new Guid().ToString()));
            Assert.That(exception.Message, Is.EqualTo(MessageUnauthoriseActionException));
        }

        [Test]

        public async Task AllClintsIdAsync_UserIdOfClient()
        {
            var dataOfClient = await dbContext.DataOfIndividualClients.FirstAsync();

            var result = await clientService.AllClintsIdAsync(dataOfClient.ApplicationUserId);

            Assert.That(result, Is.EqualTo(new List<string>() { dataOfClient.ClientId.ToString()}));
        }

        [Test]

        public async Task AllClintsIdAsync_UserIdNonClient()
        {
            var model = await dbContext.Clients.Select(x => x.Id.ToString()).ToListAsync();

            var result = await clientService.AllClintsIdAsync(new Guid().ToString());

            Assert.That(result, Is.EqualTo(model));
        }
    }
}
