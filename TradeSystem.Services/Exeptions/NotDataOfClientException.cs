namespace TradeSystem.Core.Exeptions
{
    public class NotDataOfClientException : Exception
    {
        public NotDataOfClientException() { }

        public NotDataOfClientException(string message)
            : base(message) { }      
    }
}
