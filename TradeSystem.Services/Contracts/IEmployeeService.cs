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

        public Task<IEnumerable<string>> AllCountriesNameAsync();

        public List<string> AllStatusesName();

        public Task<DataOfClientServiceModel> RejectDataDetailsAsync(Guid userId);

        public Task RejectClientDataAsync(Guid userEmployeeId, Guid userClientId);

        public Task AcceptClientDataAsync(Guid userEmployeeId, Guid userClientId);

        public Task<EmployeeFormModel> GetEmployeeFormByIdAsync(Guid employeeId);

        public Task EditAsync(Guid employeeId, EmployeeFormModel model);

        public Task SoftDeleteAsync(Guid employeeId);
    }
}
