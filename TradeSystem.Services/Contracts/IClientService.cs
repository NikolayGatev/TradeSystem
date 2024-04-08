using TradeSystem.Core.Models.Clients;
using TradeSystem.Core.Models.Employees;
using TradeSystem.Data.Models;

namespace TradeSystem.Core.Contracts
{
    public interface IClientService
    {
        public Task<bool> ExixtByIndividualClientDataIdAsync(Guid dataOfIndividualId);

        public Task<bool> ExixtByCorporativeClientDataIdAsync(Guid dataOfCorporativeId);

        public Task<bool> ExistDataIndividualClientByUserIdAsync(string userId);

        public Task<bool> ExistDataCorporativeClientByUserIdAsync(string userId);

        public Task<bool> ExistClientByUserIdAsync(string userId);

        public Task<Guid?> GetClientIdByUserIdAsync(string userId);

        public Task<IEnumerable<CountryServiceModel>> AllCountriesAsync();

        public Task<bool> CountryExistsAsync(int countryId);

        public Task<Guid> CreateDataOfIndividualClientAsync(IndividualDataClentFormModel model, string userId);

        public Task<Guid> CreateDataOfCorporativeClientAsync(CorporativeDataClentFormModel model, string userId);

        public Task<int> GetTownIdAsync(string townName, int countryId);

        public Task<Guid?> GetIdOfDataOfIndividualClientByUserIdAsync(string userId);

        public Task<Guid?> GetIdOfDataOfCorporativelClientByUserIdAsync(string userId);

        public Task<DataOfClientServiceModel> DetailsOfDataOnClientAsync(string userId);

        public Task<IndividualDataClentFormModel> GetDataOfIdividualClientFormByIdAsync(Guid dataId);

        public Task<CorporativeDataClentFormModel> GetDataOfCorporativeClientFormByIdAsync(Guid dataId);

        public Task EditDataOfCorporativeClientAsync(Guid dataOfClientId, CorporativeDataClentFormModel corporativeDataModel);

        public Task EditDataOfIndividualClientAsync(Guid dataOfClientId, IndividualDataClentFormModel individualDataModel);

        public Task DeleteAsync(Guid dataId);

        public Task<bool> ExistClientByIdAsync(Guid clientId);

        public Task<ClientAcountServiceModel> DetailsOfAcountOnClientAsync(string userId);

        public Task<IEnumerable<ClientsForAddFinancialInstumentFormServiceModel>> AllClientsAsync();

        public Task<ClientsDataQueryServiceModel> AllClientsDataAsync(
            string? nationality = null
            , string? status = null
            , string? searchTerm = null
            , string? typeOfClient = null
            , int currentPage = 1
            , int datasPerPage = 1);

        public List<string> AllTypeOfClientsName();

        public Task AddMoneyAsync(string userId, decimal amount);

        public Task<ClientAddMoneyModel> GetClintDetailsAsync(string userId);

        public Task<IEnumerable<string>> AllClintsIdAsync(string userId);

        public Task<Client?> GetClientByClientIdAcync(Guid clientId);
    }
}
