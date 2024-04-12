namespace TradeSystem.Core.Exeptions
{
    public class UnauthoriseActionException : Exception
    {
        public UnauthoriseActionException() { }

        public UnauthoriseActionException(string message)
            : base(message) { }
    }
}
