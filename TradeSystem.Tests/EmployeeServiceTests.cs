using Microsoft.EntityFrameworkCore;
using Moq;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Models.Clients;
using TradeSystem.Core.Models.Employees;
using TradeSystem.Core.Services;
using TradeSystem.Data;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;
using TradeSystem.Data.Repositories;

namespace TradeSystem.Tests
{
    [TestFixture]

    public class EmployeeServiceTests
    {
        private DbContextOptions<TradeSystemDbContext> dbOptions;
        private TradeSystemDbContext dbContext;

        private IDeletableEntityRepository<Employee> employeeRepozitory;
        private IDeletableEntityRepository<Client> clientRepozitory;
        private IDeletableEntityRepository<Country> countryRepozitory;
        private IRepository<DataOfCorporateveClient> dataCorporativeClientRepozitory;
        private IRepository<DataOfIndividualClient> dataIndividualClientRepozitory;
        private IRepository<Division> divisionRepozitory;
        private Mock<IClientService> mockClientService;

        private IEmployeeService employeeService;

        [SetUp]
        public void OneTimeSetUp()
        {
            this.dbOptions = new DbContextOptionsBuilder<TradeSystemDbContext>()
                .UseInMemoryDatabase("HouseRentingInMemory" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new TradeSystemDbContext(this.dbOptions, false);

            this.dbContext.Database.EnsureCreated();
            TradeSystem.Tests.SeedDatabase.DatabaseSeeder.SeedDatabase(this.dbContext);

            employeeRepozitory = new EfDeletableEntityRepository<Employee>(dbContext);
            clientRepozitory = new EfDeletableEntityRepository<Client>(dbContext);
            countryRepozitory = new EfDeletableEntityRepository<Country>(dbContext);
            dataCorporativeClientRepozitory = new EfRepository<DataOfCorporateveClient>(dbContext);
            dataIndividualClientRepozitory = new EfRepository<DataOfIndividualClient>(dbContext);
            divisionRepozitory = new EfRepository<Division>(dbContext);

            mockClientService = new Mock<IClientService>();


            mockClientService.Setup(x => x.ExistDataIndividualClientByUserIdAsync(new Guid().ToString()))
                    .ReturnsAsync(false);
            mockClientService.Setup(x => x.ExistDataCorporativeClientByUserIdAsync(new Guid().ToString()))
                    .ReturnsAsync(false);
            mockClientService.Setup(x => x.ExistDataIndividualClientByUserIdAsync("7586d7f6-e626-4e06-999e-7c977382c6de"))
                    .ReturnsAsync(false);
            mockClientService.Setup(x => x.ExistDataCorporativeClientByUserIdAsync("7586d7f6-e626-4e06-999e-7c977382c6de"))
                    .ReturnsAsync(true);
            mockClientService.Setup(x => x.ExistDataIndividualClientByUserIdAsync("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"))
                    .ReturnsAsync(true);

            var dataOfClientServiceModel = new DataOfClientServiceModel()
            {
                Id = Guid.Parse("3c2a6e70-1466-482c-8908-21f1ea3b5eb4"),
                UserId = "7586d7f6-e626-4e06-999e-7c977382c6de",
                DataChecking = Data.Models.Enumerations.ResultFromChecking.Accepted,
                ApplicationName = "corporative@gmail.com",
                Nationality = "Bulgaria",
                NationalityId = 1,
                Address = "Krasna Polqna 58",
                Town = "Sofia",
                PhoneNumber = "6789945435677",
                TypeOfClient = "Corporative"
            };
            mockClientService.Setup(x => x.DetailsOfDataOnClientAsync("7586d7f6-e626-4e06-999e-7c977382c6de"))
                    .ReturnsAsync(dataOfClientServiceModel);
            mockClientService.Setup(x => x.GetIdOfDataOfCorporativelClientByUserIdAsync("7586d7f6-e626-4e06-999e-7c977382c6de"))
                    .ReturnsAsync(Guid.Parse("3c2a6e70-1466-482c-8908-21f1ea3b5eb4"));
            mockClientService.Setup(x => x.GetIdOfDataOfCorporativelClientByUserIdAsync("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"))
                    .ReturnsAsync(Guid.Parse("f316a20f-0bfa-4412-81a1-50bcb6562bc0"));

            employeeService = new EmployeeService(
                employeeRepozitory
                , clientRepozitory
                , countryRepozitory
                , dataCorporativeClientRepozitory
                , dataIndividualClientRepozitory
                , divisionRepozitory
                , mockClientService.Object);
        }

        [Test]

        public async Task AllDivisionsAsync_Correct()
        {
            var model = await dbContext.Divisions.CountAsync();

            var result = await employeeService.AllDivisionsAsync();

            Assert.That(result.Count(), Is.EqualTo(model));
        }

        [Test]

        public async Task CreateEmployeeAsync_Correct()
        {
            var employeeFormModel = new EmployeeFormModel()
            {
                FirstName = "Test",
                LastName = "Test,Test",
                PhoneNumber = "1234567890",
                DivisionId = 1,
            };

            var userId = new Guid().ToString();
            var result = await employeeService.CreateEmployeeAsync(employeeFormModel, userId);

            var newEmployee = await dbContext.Employees.FirstAsync(x => x.ApplicationUserId == userId);

            Assert.That(result, Is.EqualTo(newEmployee.Id));
        }

        [Test]

        public async Task DivisionExistsAsync_Correct()
        {
            var model = await dbContext.Divisions.FirstAsync();

            var result = await employeeService.DivisionExistsAsync(model.Id);

            Assert.IsTrue(result);
        }

        [Test]

        public async Task DetailsOfEmployeeByIdAsync_Correct()
        {
            var model = await dbContext.Employees.FirstAsync();

            var result = await employeeService.DetailsOfEmployeeByIdAsync(model.Id);

            Assert.That(result.Id, Is.EqualTo(model.Id));
        }

        [Test]

        public void DetailsOfEmployeeByIdAsync_NonEmployeeException()
        {
            Assert.ThrowsAsync<NonEmployeeException>(async () => await employeeService.DetailsOfEmployeeByIdAsync(new Guid()));
        }

        [Test]

        public async Task ExistsByUserIdAsync_Correct()
        {
            var model = await dbContext.Employees.FirstAsync();

            var result = await employeeService.ExistsByUserIdAsync(model.ApplicationUserId);

            Assert.IsTrue(result);
        }

        [Test]

        public async Task ExixtByEmployeeIdAsync_Correct()
        {
            var model = await dbContext.Employees.FirstAsync();

            var result = await employeeService.ExixtByEmployeeIdAsync(model.Id);

            Assert.IsTrue(result);
        }

        [Test]

        public async Task GetIdOfEmployeeByUserIdAsync_Correct()
        {
            var model = await dbContext.Employees.FirstAsync();

            var result = await employeeService.GetIdOfEmployeeByUserIdAsync(model.ApplicationUserId);

            Assert.That(model.Id, Is.EqualTo(result));
        }

        [Test]

        public async Task GetIdOfEmployeeByUserIdAsync_UnCorrect()
        {
            var result = await employeeService.GetIdOfEmployeeByUserIdAsync(new Guid().ToString());

            Assert.IsNull(result);
        }

        [Test]

        public async Task AllCountriesNameAsync_Correct()
        {
            var model = await dbContext.Countries.Select(x => x.Name).ToListAsync();

            var result = await employeeService.AllCountriesNameAsync();

            Assert.That(model, Is.EqualTo(result));
        }

        [Test]

        public void AllStatusesName_Correct()
        {
            var result = employeeService.AllStatusesName();

            Assert.That(result.Count, Is.EqualTo(3));
        }

        [Test]

        public async Task RejectDataDetailsAsync_Correct()
        {
            var model = await dbContext.DataOfCorporateClients.FirstAsync(x => x.ApplicationUserId == "7586d7f6-e626-4e06-999e-7c977382c6de");

            var result = await employeeService.RejectDataDetailsAsync("7586d7f6-e626-4e06-999e-7c977382c6de");

            Assert.That(model.Id, Is.EqualTo(result.Id));
        }

        [Test]

        public void RejectDataDetailsAsync_NonDataOfClientException()
        {
            Assert.ThrowsAsync<NonDataOfClientException>(async () => await employeeService.RejectDataDetailsAsync(new Guid().ToString()));
        }

        [Test]

        public async Task RejectClientDataAsync_CorrectCorporative()
        {
            var employee = await dbContext.Employees.FirstAsync();

            await employeeService.RejectClientDataAsync(employee.ApplicationUserId, "7586d7f6-e626-4e06-999e-7c977382c6de");

            var result = await dbContext.DataOfCorporateClients.FirstOrDefaultAsync();

            Assert.That(result.DataChecking.ToString(), Is.EqualTo("Rejected"));
        }

        [Test]

        public async Task RejectClientDataAsync_CorrectIndividual()
        {
            var employee = await dbContext.Employees.FirstAsync();

            await employeeService.RejectClientDataAsync(employee.ApplicationUserId, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            var result = await dbContext.DataOfIndividualClients.FirstOrDefaultAsync();

            Assert.That(result.DataChecking.ToString(), Is.EqualTo("Rejected"));
        }

        [Test]

        public void RejectClientDataAsync_NonDataOfClientException()
        {
            Assert.ThrowsAsync<NonDataOfClientException>(async () => await employeeService.RejectClientDataAsync(new Guid().ToString(), new Guid().ToString()));
        }
        
        [Test]

        public async Task AcceptClientDataAsync_CorrectCorporative()
        {
            var employee = await dbContext.Employees.FirstAsync();

            await employeeService.AcceptClientDataAsync(employee.ApplicationUserId, "7586d7f6-e626-4e06-999e-7c977382c6de");

            var result = await dbContext.DataOfCorporateClients.FirstOrDefaultAsync();

            Assert.That(result.DataChecking.ToString(), Is.EqualTo("Accepted"));
        }

        [Test]

        public async Task AcceptClientDataAsync_CorrectIndividual()
        {
            var employee = await dbContext.Employees.FirstAsync();

            await employeeService.AcceptClientDataAsync(employee.ApplicationUserId, "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            var result = await dbContext.DataOfIndividualClients.FirstOrDefaultAsync();

            Assert.That(result.DataChecking.ToString(), Is.EqualTo("Accepted"));
        }

        [Test]

        public void AcceptClientDataAsync_NonDataOfClientException()
        {
            Assert.ThrowsAsync<NonDataOfClientException>(async () => await employeeService.AcceptClientDataAsync(new Guid().ToString(), new Guid().ToString()));
        }

        [Test]

        public async Task GetEmployeeFormByIdAsync_Correct()
        {
            var employee = await dbContext.Employees.FirstAsync();

            var result = await employeeService.GetEmployeeFormByIdAsync(employee.Id);

            Assert.That(result.LastName, Is.EqualTo(employee.LastName));
        }

        [Test]

        public void GetEmployeeFormByIdAsync_NonEmployeeException()
        {
            Assert.ThrowsAsync<NonEmployeeException>(async () => await employeeService.GetEmployeeFormByIdAsync(new Guid()));
        }

        [Test]

        public async Task EditAsync_Correct()
        {
            var employee = await dbContext.Employees.FirstAsync();

            var model = new EmployeeDetailsServiceModel()
            {
                Id = employee.Id,
                IsApproved = true,
                FirstName = employee.FirstName,
                LastName = "TestTest",
                PhoneNumber = employee.PhoneNumber,
                DivisionId = employee.DivisionId,
            };

            await employeeService.EditAsync( employee.Id, model);

            Assert.That(employee.LastName, Is.EqualTo("TestTest"));
        }

        [Test]

        public async Task EditAsync_NonEmployeeException()
        {
            var employee = await dbContext.Employees.FirstAsync();

            var model = new EmployeeDetailsServiceModel()
            {
                Id = employee.Id,
                IsApproved = true,
                FirstName = employee.FirstName,
                LastName = "TestTest",
                PhoneNumber = employee.PhoneNumber,
                DivisionId = employee.DivisionId,
            };
            Assert.ThrowsAsync<NonEmployeeException>(async () => await employeeService.EditAsync(new Guid(), model));
        }

        [Test]

        public async Task SoftDeleteAsync()
        {
            var employee = await dbContext.Employees.FirstAsync();

            await employeeService.SoftDeleteAsync(employee.Id);

            Assert.That(employee.IsDeleted, Is.EqualTo(true));
        }

        [Test]

        public void SoftDeleteAsync_NonEmployeeException()
        {            
            Assert.ThrowsAsync<NonEmployeeException>(async () => await employeeService.SoftDeleteAsync(new Guid()));
        }

        [Test]

        public async Task AllAsyn_WithAllChechingNull()
        {
            string userId = await dbContext.Employees.Select(x => x.ApplicationUserId).FirstAsync();
            string? employeeId = null;
            bool? isApproved = null;
            int currentPage = 1;
            int employeesPerPage = 1;

            var result = await employeeService.AllAsyn(userId, employeeId, isApproved, currentPage, employeesPerPage);


            Assert.That(result.TotalEmployeeCount, Is.EqualTo(2));
        }

        [Test]

        public async Task AllAsyn_WithemployeeIdNonNull()
        {
            var employeeIdForFilters = await dbContext.Employees.Select(x => x.Id).FirstAsync();

            string userId = await dbContext.Employees.Select(x => x.ApplicationUserId).FirstAsync();
            string? employeeId = employeeIdForFilters.ToString();
            bool? isApproved = null;
            int currentPage = 1;
            int employeesPerPage = 1;

            var result = await employeeService.AllAsyn(userId, employeeId, isApproved, currentPage, employeesPerPage);


            Assert.That(result.TotalEmployeeCount, Is.EqualTo(1));
        }

        [Test]

        public async Task AllAsyn_WithIsApprovedNonNull()
        {
            string userId = await dbContext.Employees.Select(x => x.ApplicationUserId).FirstAsync();
            string? employeeId = null;
            bool? isApproved = true;
            int currentPage = 1;
            int employeesPerPage = 1;

            var result = await employeeService.AllAsyn(userId, employeeId, isApproved, currentPage, employeesPerPage);


            Assert.That(result.TotalEmployeeCount, Is.EqualTo(2));
        }

        [Test]

        public void AllAsyn_UnauthoriseActionException()
        {
            string userId = new Guid().ToString();
            string? employeeId = null;
            bool? isApproved = true;
            int currentPage = 1;
            int employeesPerPage = 1;

            Assert.ThrowsAsync<UnauthoriseActionException>(async ()=> await employeeService.AllAsyn(userId, employeeId, isApproved, currentPage, employeesPerPage));
        }
    }
}
