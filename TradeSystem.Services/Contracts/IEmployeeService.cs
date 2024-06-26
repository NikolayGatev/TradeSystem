﻿using TradeSystem.Core.Models.Administrator;
using TradeSystem.Core.Models.Clients;
using TradeSystem.Core.Models.Employees;

namespace TradeSystem.Core.Contracts
{
    public interface IEmployeeService
    {
        public Task<bool> ExixtByEmployeeIdAsync(Guid employeeId);

        public Task<bool> ExistsByUserIdAsync(string userId);

        public Task<IEnumerable<DivisionServiceModel>> AllDivisionsAsync();

        public Task<bool> DivisionExistsAsync(int divisionId);

        public Task<Guid?> GetIdOfEmployeeByUserIdAsync(string userId);

        public Task<Guid> CreateEmployeeAsync(EmployeeFormModel model, string userId);

        public Task<EmployeeDetailsServiceModel> DetailsOfEmployeeByIdAsync(Guid employeeId);

        public Task<IEnumerable<string>> AllCountriesNameAsync();

        public List<string> AllStatusesName();

        public Task<DataOfClientServiceModel> RejectDataDetailsAsync(string userId);

        public Task RejectClientDataAsync(string userEmployeeId, string userClientId);

        public Task AcceptClientDataAsync(string userEmployeeId, string userClientId);

        public Task<EmployeeDetailsServiceModel> GetEmployeeFormByIdAsync(Guid employeeId);

        public Task EditAsync(Guid employeeId, EmployeeDetailsServiceModel model);

        public Task SoftDeleteAsync(Guid employeeId);

        public Task<EmployeeQueryServiceModel> AllAsyn(string userId
            , string? EmployeeId = null
            , bool? IsApproved = null
            , int currentPage = 1
            , int employeesPerPage = 1);
    }
}
