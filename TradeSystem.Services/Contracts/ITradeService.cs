using TradeSystem.Core.Models.Enums;
using TradeSystem.Core.Models.Orders;
using TradeSystem.Core.Models.Trades;
using TradeSystem.Data.Models;

namespace TradeSystem.Core.Contracts
{
    public interface ITradeService
    {
        Task<bool> UsarIdIsCounterpartyByTrade(Guid UserId, Guid tradeId);

        Task<IEnumerable<OrdersOfTradeServiceModel>> GetOrdersOfTradeByIdAsync(Guid tradeId);

        Task<TradeDetailsServiceModel> GetTradeDetailsByIdAsync(Guid tradeId, string userId);

        Task<Trade?> GetTradeByIdAsync(Guid tradeId);

        Task<bool> ExistTradeByIdAsync(Guid tradeId);

        Task DeleteAsync(Guid tradeId, string userId);

        Task<TradeQueryServiceModel> AllAsyn(string userId
            , string? ClientAccountId = null
            , bool? isBid = null
            , string? ISIN = null
            , string? searchTerm = null
            , TradeSorting sorting = TradeSorting.Newest
            , int currentPage = 1
            , int tradesPerPage = 1);

        Task<IEnumerable<RealTimeTradeServiceModel>> RealTimeTrdeAcync();
    }
}
