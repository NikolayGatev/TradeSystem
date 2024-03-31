using TradeSystem.Core.Models.Enums;
using TradeSystem.Core.Models.Orders;
using TradeSystem.Data.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TradeSystem.Core.Contracts
{
    public interface IOrderService
    {
        Task<IEnumerable<FinInstrumentServiceModel>> AllFinancialInstrumentsAsync(Guid? userId);

        Task<Guid> CreateAsync(OrderFormModel model, Guid? clientId);

        Task<OrderDetailsServiceModel> GetOrderDetailsByIdAsync(Guid orderId, Guid userId);

        Task<Order?> GetOrderByIdAsync(Guid orderId);

        Task DeleteAsync(Guid orderId, Guid userId);

        Task<OrderQueryServiceModel> AllAsyn(Guid userId
            ,string? ClientAccountId = null
            , bool? IsBid = null
            , bool?  IsNotActive = null
            , string? ISIN = null
            , string? searchTerm = null
            , OrderSorting sorting = OrderSorting.Newest
            , int currentPage = 1
            , int ordersPerPage = 1);

        Task<IEnumerable<string>> AllClintsIdAsync(Guid userId);

        Task<bool> NotEnoughMoneyAsync(Guid? clientId, decimal sum);

        Task<decimal> GetBalanceByUserIdAsync(Guid userId);
    }
}
