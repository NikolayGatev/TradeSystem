using TradeSystem.Core.Models.Clients;
using TradeSystem.Core.Models.Employees;

namespace TradeSystem.Core.Contracts
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<DivisionServiceModel>> AllDivisionsAsync();

        public Task<bool> DivisionExistsAsync(int divisionId);

        public Task<Guid?> GetIdOfEmployeeByUserIdAsync(Guid userId);

        public Task<Guid> CreateEmployeeAsync(EmployeeFormModel model, Guid userId);
    }
}
