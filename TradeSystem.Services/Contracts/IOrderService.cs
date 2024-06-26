﻿using TradeSystem.Core.Models.Enums;
using TradeSystem.Core.Models.Orders;
using TradeSystem.Data.Models;

namespace TradeSystem.Core.Contracts
{
    public interface IOrderService
    {
        Task<Guid> CreateAsync(OrderFormModel model, Guid clientId);

        Task<OrderDetailsServiceModel> GetOrderDetailsByIdAsync(Guid orderId, string userId);

        Task<bool> ExistOrderByIdAsync(Guid orderId);

        Task<Order?> GetOrderByIdAsync(Guid orderId);

        Task DeleteAsync(Guid orderId, string userId);

        Task<OrderQueryServiceModel> AllAsyn(string userId
            ,string? clientAccountId = null
            , bool? isBid = null
            , bool?  isNotActive = null
            , string? ISIN = null
            , string? searchTerm = null
            , OrderSorting sorting = OrderSorting.Newest
            , int currentPage = 1
            , int ordersPerPage = 1);

        Task<decimal> GetBalanceByUserIdAsync(string userId);

        Task DeleteAllOredersByFinancialInstrumentAsync(int financialInstrumentId, string userId);
    }
}
