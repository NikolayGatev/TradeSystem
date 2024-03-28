namespace TradeSystem.Core.Exeptions
{
    public class ExistFinancialInstrumentWithThisNameOrISIN : Exception
    {
        public ExistFinancialInstrumentWithThisNameOrISIN() { }

        public ExistFinancialInstrumentWithThisNameOrISIN(string message)
            : base(message) { }
    }
}
