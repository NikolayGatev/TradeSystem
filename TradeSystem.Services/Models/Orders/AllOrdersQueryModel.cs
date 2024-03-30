using System.ComponentModel.DataAnnotations;
using TradeSystem.Core.Models.Enums;

namespace TradeSystem.Core.Models.Orders
{
    public class AllOrdersQueryModel
    {
        public AllOrdersQueryModel()
        {
            this.Orders = new HashSet<OrderDetailsServiceModel>();
            this.BidAsk = new string[] { "buy", "sell" };
            this.IsDelete = new string[] { "Active", "Not active" };
        }

        public int OrdersPerPage { get; } = 3;

        public string ISIN { get; init; } = null!;

        [Display(Name = "Active")]

        public bool? IsNotActive { get; init; } = null!;

        [Display(Name = "Type: buy or sell")]

        public bool? IsBid { get; init; } = null!;

        public string ClientAccountId { get; init; } = null!;

        [Display(Name = "Search by text")]

        public string SearchTerm { get; init; } = null!;

        public OrderSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalOrdersCount { get; set; }

        public IEnumerable<string> ISINs { get; set; } = null!;

        public IEnumerable<string> ClientAccountIds { get; set; } = null!;

        public IEnumerable<string> IsDelete { get; set; }

        public IEnumerable<string> BidAsk { get; set; }

        public IEnumerable<OrderDetailsServiceModel> Orders { get; set; }
    }
}
