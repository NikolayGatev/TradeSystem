namespace TradeSystem.Core.Models.Orders
{
    public class OrderQueryServiceModel
    {
        public OrderQueryServiceModel()
        {
            this.Orders = new HashSet<OrderDetailsServiceModel>();
        }
        public int TotalOrdersCount { get; set; }

        public IEnumerable<OrderDetailsServiceModel> Orders { get; set; }
    }
}
