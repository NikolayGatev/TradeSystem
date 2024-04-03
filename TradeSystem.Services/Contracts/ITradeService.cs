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

        Task<TradeDetailsServiceModel> GetTradeDetailsByIdAsync(Guid tradeId, Guid userId);

        Task<Trade?> GetTradeByIdAsync(Guid tradeId);

        Task<bool> ExistTradeByIdAsync(Guid tradeId);

        Task DeleteAsync(Guid tradeId, Guid userId);

        Task<TradeQueryServiceModel> AllAsyn(Guid userId
            , string? ClientAccountId = null
            , bool? IsBid = null
            , string? ISIN = null
            , string? searchTerm = null
            , TradeSorting sorting = TradeSorting.Newest
            , int currentPage = 1
            , int ordersPerPage = 1);

        Task<IEnumerable<RealTimeTradeServiceModel>> RealTimeTrdeAcync();
    }
}
