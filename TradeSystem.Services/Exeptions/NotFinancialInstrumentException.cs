namespace TradeSystem.Core.Exeptions
{
    public class NotFinancialInstrumentException : Exception
    {
        public NotFinancialInstrumentException() { }

        public NotFinancialInstrumentException(string message)
            : base(message) { }
    }
}
