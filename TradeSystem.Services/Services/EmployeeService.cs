using Microsoft.EntityFrameworkCore;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Models.Clients;
using TradeSystem.Core.Models.Employees;
using TradeSystem.Core.Models.Enums;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;
using TradeSystem.Data.Models.Enumerations;
using static TradeSystem.Common.ExceptionMessages;

namespace TradeSystem.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDeletableEntityRepository<Employee> employeeRepozitory;
        private readonly IDeletableEntityRepository<ApplicationUser> aplicationUserRepozitory;
        private readonly IDeletableEntityRepository<Client> clientRepozitory;
        private readonly IDeletableEntityRepository<ClientFinancialInstrument> clientFinancialInstrumentRepozitory;
        private readonly IRepository<Country> countryRepozitory;
        private readonly IRepository<DataOfCorporateveClient> dataCorporativeClientRepozitory;
        private readonly IRepository<DataOfIndividualClient> dataIndividualClientRepozitory;
        private readonly IRepository<Division> divisionRepozitory;
        private readonly IDeletableEntityRepository<FinancialInstrument> finInstrRepozitory;
        private readonly IRepository<IdentityDocument> identityDocRepozitory;
        private readonly IDeletableEntityRepository<Order> orderRepozitory;
        private readonly IDeletableEntityRepository<Town> townRepozitory;
        private readonly IDeletableEntityRepository<Trade> tradeRepozitory;
        private readonly IDeletableEntityRepository<TradeOrder> tradeOrderRepozitory;
        private readonly IClientService clientService;

        public EmployeeService(
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
                   ,IClientService clientService)
                   
        {
            this.employeeRepozitory = employeeRepozitory;
            this.aplicationUserRepozitory = aplicationUserRepozitory;
            this.clientRepozitory = clientRepozitory;
            this.clientFinancialInstrumentRepozitory = clientFinancialInstrumentRepozitory;
            this.countryRepozitory = countryRepozitory;
            this.dataCorporativeClientRepozitory = dataCorporativeClientRepozitory;
            this.dataIndividualClientRepozitory = dataIndividualClientRepozitory;
            this.divisionRepozitory = divisionRepozitory;
            this.finInstrRepozitory = finInstrRepozitory;
            this.identityDocRepozitory = identityDocRepozitory;
            this.orderRepozitory = orderRepozitory;
            this.townRepozitory = townRepozitory;
            this.tradeRepozitory = tradeRepozitory;
            this.tradeOrderRepozitory = tradeOrderRepozitory;
            this.clientService = clientService;
        }

        public async Task<IEnumerable<DivisionServiceModel>> AllDivisionsAsync()
        {
            return await divisionRepozitory.AllAsNoTracking()
                .Select(d => new DivisionServiceModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                })
                .ToListAsync();
        }

        public async Task<Guid> CreateEmployeeAsync(EmployeeFormModel model, Guid userId)
        {
            Employee employee = new Employee()
            {
                ApplicationUserId = userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                DivisionId = model.DivisionId,
            };

            await employeeRepozitory.AddAsync(employee);
            await employeeRepozitory.SaveChangesAsync();

            return employee.Id;
        }

        public async Task<bool> DivisionExistsAsync(int divisionId)
        {
            return await divisionRepozitory.AllAsNoTracking()
                .AnyAsync(d => d.Id == divisionId);
        }

        public async Task<EmployeeDetailsServiceModel> DetailsOfEmployeeByIdAsync(Guid employeeId)
        {
            var model = await employeeRepozitory.AllAsNoTracking()
                .Where(e => e.Id == employeeId)
                .Select(e => new EmployeeDetailsServiceModel()
                {
                    Id=e.Id,
                    ApplicationName = e.ApplicationUser.UserName,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    PhoneNumber = e.PhoneNumber,
                    DivisionId=e.DivisionId,
                    DivisionName = e.Division.Name,
                })
                .FirstAsync();

            if (model == null)
            {
                throw new NonEmployeeException(MessageNotEmployeeException);
            }
            return model;
        }

        public async Task<bool> ExistsByUserIdAsync(Guid userId)
        {
            return await employeeRepozitory.AllAsNoTracking()
                .AnyAsync(e => e.ApplicationUserId == userId);
        }

        public async Task<bool> ExixtByEmployeeIdAsync(Guid employeeId)
        {
            return await employeeRepozitory.AllAsNoTracking()
                .AnyAsync(e => e.Id == employeeId);
        }

        public async Task<Guid?> GetIdOfEmployeeByUserIdAsync(Guid userId)
        {
            return (await employeeRepozitory.AllAsNoTracking()
                .FirstOrDefaultAsync(e => e.ApplicationUserId == userId))?.Id;
        }

        public async Task<IEnumerable<string>> AllCountriesNameAsync()
        {
            return await countryRepozitory.AllAsNoTracking()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public List<string> AllStatusesName()
        {
            return Enum.GetNames(typeof(ResultFromChecking)).ToList();
        }

        public async Task<DataOfClientServiceModel> RejectDataDetailsAsync(Guid userId)
        {
            if (await clientService.ExistDataCorporativeClientByUserIdAsync(userId) == false
                && await clientService.ExistDataIndividualClientByUserIdAsync(userId) == false)
            {
                throw new NonDataOfClientException(MessageNotDataException);
            }

            return await clientService.DetailsOfDataOnClientAsync(userId);
        }

        public async Task RejectClientDataAsync(Guid userEmployeeId, Guid userClientId)
        {
            if (await clientService.ExistDataCorporativeClientByUserIdAsync(userClientId) == false
                && await clientService.ExistDataIndividualClientByUserIdAsync(userClientId) == false)
            {
                throw new NonDataOfClientException(MessageNotDataException);
            }

            var dataId = await clientService.GetIdOfDataOfCorporativelClientByUserIdAsync(userClientId)
                ?? await clientService.GetIdOfDataOfIndividualClientByUserIdAsync(userClientId);

            var dataCorporativeClient = await dataCorporativeClientRepozitory.All()
                .FirstOrDefaultAsync(d => d.Id == dataId);
            var dataIndividualClient = await dataIndividualClientRepozitory.All()
                .FirstOrDefaultAsync(d => d.Id == dataId);

            if (dataCorporativeClient != null)
            {
                dataCorporativeClient.DataChecking = ResultFromChecking.Rejected;
                dataCorporativeClient.AuthorisedOn = DateTime.UtcNow;
                dataCorporativeClient.EmployeeId = await GetIdOfEmployeeByUserIdAsync(userEmployeeId);

                await dataCorporativeClientRepozitory.SaveChangesAsync();
            }
            else if (dataIndividualClient != null)
            {
                dataIndividualClient.DataChecking = ResultFromChecking.Rejected;
                dataIndividualClient.AuthorisedOn = DateTime.UtcNow;
                dataIndividualClient.EmployeeId = await GetIdOfEmployeeByUserIdAsync(userEmployeeId);

                await dataIndividualClientRepozitory.SaveChangesAsync();
            }          
        }

        public async Task AcceptClientDataAsync(Guid userEmployeeId, Guid userClientId)
        {
            if (await clientService.ExistDataCorporativeClientByUserIdAsync(userClientId) == false
               && await clientService.ExistDataIndividualClientByUserIdAsync(userClientId) == false)
            {
                throw new NonDataOfClientException(MessageNotDataException);
            }

            var dataId = await clientService.GetIdOfDataOfCorporativelClientByUserIdAsync(userClientId)
                ?? await clientService.GetIdOfDataOfIndividualClientByUserIdAsync(userClientId);

            var dataCorporativeClient = await dataCorporativeClientRepozitory.All()
                .FirstOrDefaultAsync(d => d.Id == dataId);
            var dataIndividualClient = await dataIndividualClientRepozitory.All()
                .FirstOrDefaultAsync(d => d.Id == dataId);

            if (dataCorporativeClient != null)
            {
                dataCorporativeClient.DataChecking = ResultFromChecking.Accepted;
                dataCorporativeClient.AuthorisedOn = DateTime.UtcNow;
                dataCorporativeClient.EmployeeId = await GetIdOfEmployeeByUserIdAsync(userEmployeeId);

                var client = new Client()
                {
                    IsIndividual = false,
                    Balance = 0,
                };

                await clientRepozitory.AddAsync(client);
                await clientRepozitory.SaveChangesAsync();

                dataCorporativeClient.Client = client;

                await dataCorporativeClientRepozitory.SaveChangesAsync();
            }
            else if (dataIndividualClient != null)
            {
                dataIndividualClient.DataChecking = ResultFromChecking.Accepted;
                dataIndividualClient.AuthorisedOn = DateTime.UtcNow;
                dataIndividualClient.EmployeeId = await GetIdOfEmployeeByUserIdAsync(userEmployeeId);

                var client = new Client()
                {
                    IsIndividual = true,
                    Balance = 0,
                };

                await clientRepozitory.AddAsync(client);
                await clientRepozitory.SaveChangesAsync();

                dataIndividualClient.ClientId = client.Id;

                await dataIndividualClientRepozitory.SaveChangesAsync();
            }
        }

        public async Task<EmployeeFormModel> GetEmployeeFormByIdAsync(Guid employeeId)
        {
            var employee = await employeeRepozitory.AllAsNoTracking()

                .Where(e => e.Id == employeeId)
                .Select(e => new EmployeeFormModel()
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    PhoneNumber = e.PhoneNumber,
                    DivisionId = e.DivisionId,
                })
                .FirstOrDefaultAsync();

            if (employee == null)
            {
                throw new NonEmployeeException(MessageNotEmployeeException);
            }

            employee.Divisions = await AllDivisionsAsync();            

            return employee;
        }

        public async Task EditAsync(Guid employeeId, EmployeeFormModel model)
        {
            var employee = await employeeRepozitory.All()
                .Where(e => e.Id == employeeId)
                .FirstOrDefaultAsync();

            if (employee == null)
            {
                throw new NonEmployeeException(MessageNotEmployeeException);
            }

            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.PhoneNumber = model.PhoneNumber;
            employee.DivisionId = model.DivisionId;

            await employeeRepozitory.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(Guid employeeId)
        {
            if(await ExixtByEmployeeIdAsync(employeeId) == false)
            {
                throw new NonEmployeeException(MessageNotEmployeeException);
            }
            var entity = await employeeRepozitory.All()
                .FirstAsync(e => e.Id == employeeId);

            employeeRepozitory.Delete(entity);

            await employeeRepozitory.SaveChangesAsync();
        }
    }
}
