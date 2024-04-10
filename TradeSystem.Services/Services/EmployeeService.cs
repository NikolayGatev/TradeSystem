using Microsoft.EntityFrameworkCore;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Exeptions;
using TradeSystem.Core.Models.Administrator;
using TradeSystem.Core.Models.Clients;
using TradeSystem.Core.Models.Employees;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;
using TradeSystem.Data.Models.Enumerations;
using static TradeSystem.Common.ExceptionMessages;

namespace TradeSystem.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDeletableEntityRepository<Employee> employeeRepozitory;
        private readonly IDeletableEntityRepository<Client> clientRepozitory;
        private readonly IRepository<Country> countryRepozitory;
        private readonly IRepository<DataOfCorporateveClient> dataCorporativeClientRepozitory;
        private readonly IRepository<DataOfIndividualClient> dataIndividualClientRepozitory;
        private readonly IRepository<Division> divisionRepozitory;
        private readonly IClientService clientService;

        public EmployeeService(
                   IDeletableEntityRepository<Employee> employeeRepozitory
                   , IDeletableEntityRepository<Client> clientRepozitory
                   , IRepository<Country> countryRepozitory
                   , IRepository<DataOfCorporateveClient> dataCorporativeClientRepozitory
                   , IRepository<DataOfIndividualClient> dataIndividualClientRepozitory
                   , IRepository<Division> divisionRepozitory
                   ,IClientService clientService)
                   
        {
            this.employeeRepozitory = employeeRepozitory;
            this.clientRepozitory = clientRepozitory;
            this.dataCorporativeClientRepozitory = dataCorporativeClientRepozitory;
            this.dataIndividualClientRepozitory = dataIndividualClientRepozitory;
            this.divisionRepozitory = divisionRepozitory;
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

        public async Task<Guid> CreateEmployeeAsync(EmployeeFormModel model, string userId)
        {
            Employee employee = new Employee()
            {
                ApplicationUserId = userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                DivisionId = model.DivisionId,
                IsApproved = false,
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
                    IsApproved = e.IsApproved,
                })
                .FirstAsync();

            if (model == null)
            {
                throw new NonEmployeeException(MessageNotEmployeeException);
            }
            return model;
        }

        public async Task<bool> ExistsByUserIdAsync(string userId)
        {
            return await employeeRepozitory.AllAsNoTracking()
                .Where(e => e.IsApproved)
                .AnyAsync(e => e.ApplicationUserId == userId);
        }

        public async Task<bool> ExixtByEmployeeIdAsync(Guid employeeId)
        {
            return await employeeRepozitory.AllAsNoTracking()
                .AnyAsync(e => e.Id == employeeId);
        }

        public async Task<Guid?> GetIdOfEmployeeByUserIdAsync(string userId)
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

        public async Task<DataOfClientServiceModel> RejectDataDetailsAsync(string userId)
        {
            if (await clientService.ExistDataCorporativeClientByUserIdAsync(userId) == false
                && await clientService.ExistDataIndividualClientByUserIdAsync(userId) == false)
            {
                throw new NonDataOfClientException(MessageNotDataException);
            }

            return await clientService.DetailsOfDataOnClientAsync(userId);
        }

        public async Task RejectClientDataAsync(string userEmployeeId, string userClientId)
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

        public async Task AcceptClientDataAsync(string userEmployeeId, string userClientId)
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

        public async Task<EmployeeDetailsServiceModel> GetEmployeeFormByIdAsync(Guid employeeId)
        {
            var employee = await employeeRepozitory.AllAsNoTracking()

                .Where(e => e.Id == employeeId)
                .Select(e => new EmployeeDetailsServiceModel()
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    PhoneNumber = e.PhoneNumber,
                    DivisionId = e.DivisionId,
                    IsApproved = e.IsApproved,
                })
                .FirstOrDefaultAsync();

            if (employee == null)
            {
                throw new NonEmployeeException(MessageNotEmployeeException);
            }

            employee.Divisions = await AllDivisionsAsync();            

            return employee;
        }

        public async Task EditAsync(Guid employeeId, EmployeeDetailsServiceModel model)
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
            employee.IsApproved = model.IsApproved;

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
                
        public async Task<EmployeeQueryServiceModel> AllAsyn(
            string userId
            , string? employeeId = null
            , bool? isApproved = null
            , int currentPage = 1
            , int employeesPerPage = 1)
        {
            if (await ExistsByUserIdAsync(userId) == false)
            {
                throw new UnauthoriseActionException(MessageUnauthoriseActionException);
            }

            var employeeToShow = employeeRepozitory.AllAsNoTracking();

            if (isApproved != null)
            {
                employeeToShow = employeeToShow
                    .Where(e => e.IsApproved == isApproved);
            }

            if (employeeId != null
                && Guid.TryParse(employeeId, out Guid id)
                && (await employeeRepozitory.AllAsNoTracking().Where(e => e.Id == id).AnyAsync()))
            {
                employeeToShow = employeeToShow
                    .Where(e => e.Id == id);
            }

            if (isApproved != null)
            {
                employeeToShow = employeeToShow
                    .Where(e => e.IsApproved == isApproved);
            }

            var employees = await employeeToShow
                .Skip((currentPage - 1) * employeesPerPage)
                .Take(employeesPerPage)
                .Select(e => new EmployeeDetailsServiceModel()
                {
                    Id = e.Id,
                    ApplicationName = e.ApplicationUser.UserName,
                    DivisionName = e.Division.Name,
                    IsApproved = e.IsApproved,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    PhoneNumber = e.PhoneNumber,
                    DivisionId = e.DivisionId,
                })
                .ToListAsync();

            int totalEmployees = employeeId != null
                ? await employeeToShow.Where(e => e.Id == Guid.Parse(employeeId)).CountAsync()
                : await employeeToShow.CountAsync();

            return new EmployeeQueryServiceModel()
            {
                Employees = employees,
                TotalEmployeeCount = totalEmployees,
            };
        }
    }
}
