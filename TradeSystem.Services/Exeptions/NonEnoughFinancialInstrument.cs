namespace TradeSystem.Core.Exeptions
{
    public class NonEnoughFinancialInstrument : Exception
    {
        public NonEnoughFinancialInstrument() { }

        public NonEnoughFinancialInstrument(string message)
            : base() { }
    }
}
