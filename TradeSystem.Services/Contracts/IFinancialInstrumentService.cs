using TradeSystem.Core.Models.Enums;
using TradeSystem.Core.Models.FinacialInstrument;
using TradeSystem.Data.Models;

namespace TradeSystem.Core.Contracts
{
    public interface IFinancialInstrumentService
    {
        public Task<bool> ExixtFinancialInstrumentAsync(int Id);

        public Task<FinancialInstrument?> GetFinancialInstrumentByIdAsync(int Id);

        public Task<int> CreateAsync(FinacialInstrumentFormModel model);

        public Task<FinInstrumentDetailsServiceModel> GetFinInstrumentDetailsByIdAsync(int id);

        public Task<FinacialInstrumentFormModel> GetEditAsync(int id);

        public Task EditAsyn(int id, FinacialInstrumentFormModel model);

        public Task DeleteAsync(int id);

        public Task<FinancialInstrumentQueryServiceModel> AllAsyn(
            string? ISIN = null
            , string? searchTerm = null
            , FinInstrumentsSorting sorting = FinInstrumentsSorting.Newest
            , int currentPage = 1
            , int finInstrumentsPerPage = 1);

        public Task<IEnumerable<string>> AllISINsAsync();
    }
}
