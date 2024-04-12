namespace TradeSystem.Core.Exeptions
{
    public class NonExistFinancialInstrumentWithThisNameOrISIN : Exception
    {
        public NonExistFinancialInstrumentWithThisNameOrISIN() { }

        public NonExistFinancialInstrumentWithThisNameOrISIN(string message)
            : base(message) { }
    }
}
