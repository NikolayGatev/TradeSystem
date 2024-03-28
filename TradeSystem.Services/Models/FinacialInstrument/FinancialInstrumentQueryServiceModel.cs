namespace TradeSystem.Core.Models.FinacialInstrument
{
    public class FinancialInstrumentQueryServiceModel
    {
        public FinancialInstrumentQueryServiceModel()
        {
            this.FinancialInstruments = new HashSet<FinInstrumentDetailsServiceModel>();
        }

        public int TotalFinInstrumentCount { get; set; }

        public IEnumerable<FinInstrumentDetailsServiceModel> FinancialInstruments { get; set; }
    }
}
