using System.ComponentModel.DataAnnotations;
using TradeSystem.Core.Models.Enums;
using TradeSystem.Core.Models.Orders;

namespace TradeSystem.Core.Models.Trades
{
    public class AllTradesQueryModel
    {
        public AllTradesQueryModel()
        {
            this.Trades = new HashSet<TradeDetailsServiceModel>();
            this.BidAsk = new string[] { "buy", "sell" };
        }

        public int TradesPerPage { get; } = 3;

        public string ISIN { get; init; } = null!;

        [Display(Name = "Type")]

        public bool? IsBid { get; set; } = null!; 

        public string ClientAccountId { get; init; } = null!;

        [Display(Name = "Search by text")]

        public string SearchTerm { get; init; } = null!;

        public TradeSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalTradesCount { get; set; }

        public IEnumerable<string> ISINs { get; set; } = null!;

        public IEnumerable<string> ClientAccountIds { get; set; } = null!;

        public IEnumerable<string> BidAsk { get; set; }

        public IEnumerable<TradeDetailsServiceModel> Trades { get; set; }
    }
}
