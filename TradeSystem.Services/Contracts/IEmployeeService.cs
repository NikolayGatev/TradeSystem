using TradeSystem.Core.Models.Clients;
using TradeSystem.Core.Models.Employees;
using TradeSystem.Data.Models;

namespace TradeSystem.Core.Contracts
{
    public interface IEmployeeService
    {
        public Task<bool> ExixtByEmployeeIdAsync(Guid employeeId);

        public Task<bool> ExistsByUserIdAsync(Guid userId);

        public Task<IEnumerable<DivisionServiceModel>> AllDivisionsAsync();

        public Task<bool> DivisionExistsAsync(int divisionId);

        public Task<Guid?> GetIdOfEmployeeByUserIdAsync(Guid userId);

        public Task<Guid> CreateEmployeeAsync(EmployeeFormModel model, Guid userId);

        public Task<EmployeeDetailsServiceModel> DetailsOfEmployeeByIdAsync(Guid employeeId);
    }
}
