using TradeSystem.Core.Models.Clients;

namespace TradeSystem.Core.Contracts
{
    public interface IClientService
    {
        public Task<IEnumerable<CountryServiceModel>> AllCountriesAsync();

        public Task<bool> CountryExistsAsync(int countryId);

        public Task<Guid> CreateDataOfIndividualClientAsync(IndividualDataClentFormModel model, Guid userId);

        public Task<int> GetTownIdAsync(string townName, int countryId);

        public Task<Guid?> GetDataOfIndividualClientByIdAsync(Guid userId);

        public Task<Guid?> GetDataOfCorporativelClientByIdAsync(Guid userId);
    }
}
