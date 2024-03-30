namespace TradeSystem.Core.Exeptions
{
    public class NonFinancialInstrumentException : Exception
    {
        public NonFinancialInstrumentException() { }

        public NonFinancialInstrumentException(string message)
            : base(message) { }
    }
}
