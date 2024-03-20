using Microsoft.EntityFrameworkCore;
using TradeSystem.Core.Contracts;
using TradeSystem.Core.Models.Clients;
using TradeSystem.Core.Models.Employees;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;

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
        private readonly IDeletableEntityRepository<DepositedMoney> depositMoneyRepozitory;
        private readonly IRepository<Division> divisionRepozitory;
        private readonly IDeletableEntityRepository<FinancialInstrument> finInstrRepozitory;
        private readonly IRepository<IdentityDocument> identityDocRepozitory;
        private readonly IDeletableEntityRepository<Order> orderRepozitory;
        private readonly IDeletableEntityRepository<Town> townRepozitory;
        private readonly IDeletableEntityRepository<Trade> tradeRepozitory;
        private readonly IDeletableEntityRepository<TradeOrder> tradeOrderRepozitory;

        public EmployeeService(
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
                   , IDeletableEntityRepository<TradeOrder> tradeOrderRepozitory)

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

        public async Task<Guid?> GetIdOfEmployeeByUserIdAsync(Guid userId)
        {
            return (await employeeRepozitory.AllAsNoTracking()
                .FirstOrDefaultAsync(e => e.ApplicationUserId == userId))?.Id;
        }
    }
}
