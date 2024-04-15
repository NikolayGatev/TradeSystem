namespace TradeSystem.Core.Services
{
    public class NonEnoughMoney : Exception
    {
        public NonEnoughMoney() { }

        public NonEnoughMoney (string message)
            : base() { }
    }
}
