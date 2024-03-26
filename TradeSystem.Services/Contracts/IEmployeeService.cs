using TradeSystem.Core.Models.Clients;
using TradeSystem.Core.Models.Employees;

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

        public Task<ClientsDataQueryServiceModel> AllClientsDataAsync(
            string? nationality = null
            ,string? status = null
            ,string? searchTerm = null
            ,string? typeOfClient = null
            , int currentPage = 1
            , int datasPerPage = 1);

        public Task<IEnumerable<string>> AllCountriesNameAsync();

        public List<string> AllStatusesName();

        public List<string> AllTypeOfClientsName();

        public Task<DataOfClientServiceModel> RejectDataDetailsAsync(Guid userId);

        public Task RejectClientDataAsync(Guid userEmployeeId, Guid userClientId);

        public Task AcceptClientDataAsync(Guid userEmployeeId, Guid userClientId);

    }
}
