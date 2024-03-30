namespace TradeSystem.Core.Exeptions
{
    public class NonDataOfClientException : Exception
    {
        public NonDataOfClientException() { }

        public NonDataOfClientException(string message)
            : base(message) { }      
    }
}
