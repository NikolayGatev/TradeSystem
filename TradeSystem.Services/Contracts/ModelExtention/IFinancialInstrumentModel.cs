namespace TradeSystem.Core.Contracts.ModelExtention
{
    public interface IFinancialInstrumentModel
    {
        public string Name { get; set; }

        public string ISIN { get; set; }
    }
}
