namespace TradeSystem.Core.Models.Trades
{
    public class TradeQueryServiceModel
    {
        public TradeQueryServiceModel()
        {
            this.Trades = new HashSet<TradeDetailsServiceModel>();
        }
        public int TotalTradesCount { get; set; }

        public IEnumerable<TradeDetailsServiceModel> Trades { get; set; }
    }
}
