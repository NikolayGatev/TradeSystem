namespace TradeSystem.Core.Models.Orders
{
    public class OrdersOfTradeServiceModel
    {
        public Guid OrderId { get; set; }

        public Guid ClientId { get; set; }

        public uint CurrentExecuted { get; set; }

        public uint InitialVolume { get; set; }

        public string IsBid { get; set; } = null!;
    }
}
