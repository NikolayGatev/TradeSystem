using System.ComponentModel.DataAnnotations;
using TradeSystem.Core.Models.Orders;

namespace TradeSystem.Core.Models.Trades
{
    public class TradeDetailsServiceModel
    {
        public Guid Id { get; set; }

        public string CreatedOn { get; set; } = null!;

        public uint Volume { get; set; }

        public decimal Price { get; set; }

        public decimal Turnover { get; set; }

        public int FinancialInstrumentId { get; set; }

        [Display(Name = "Name of financial instrument")]

        public string FinancialInstrumentName { get; set; } = null!;

        public string? BidAsk { get; set; }

        public IEnumerable<OrdersOfTradeServiceModel>? Orders { get; set; }
    }
}
