using TradeSystem.Core.Models.Clients;

namespace TradeSystem.Core.Contracts
{
    public interface IClientService
    {
        public Task<bool> ExixtByIndividualClientDataIdAsync(Guid dataOfIndividualId);

        public Task<bool> ExixtByCorporativeClientDataIdAsync(Guid dataOfCorporativeId);

        public Task<bool> ExistDataIndividualClientByUserIdAsync(Guid userId);

        public Task<bool> ExistDataCorporativeClientByUserIdAsync(Guid userId);

        public Task<IEnumerable<CountryServiceModel>> AllCountriesAsync();

        public Task<bool> CountryExistsAsync(int countryId);

        public Task<Guid> CreateDataOfIndividualClientAsync(IndividualDataClentFormModel model, Guid userId);

        public Task<int> GetTownIdAsync(string townName, int countryId);

        public Task<Guid?> GetIdOfDataOfIndividualClientByUserIdAsync(Guid userId);

        public Task<Guid?> GetIdOfDataOfCorporativelClientByUserIdAsync(Guid userId);

        public Task<DataOfClientServiceModel> DetailsOfDataOnClientAsync(Guid userId);

    }
}
