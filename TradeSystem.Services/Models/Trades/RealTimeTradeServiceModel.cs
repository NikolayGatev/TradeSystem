using TradeSystem.Core.Contracts.ModelExtention;

namespace TradeSystem.Core.Models.Trades
{
    public class RealTimeTradeServiceModel : IFinancialInstrumentModel
    {
        public string ISIN { get; set; } = null!;

        public string Name { get; set; } = null!;

        public int FinancialInstrumentId { get; set; }

        public string TimeOfTrade { get; set; } = null!;

        public decimal Price { get; set; }

        public uint Volume { get; set; }
    }
}
