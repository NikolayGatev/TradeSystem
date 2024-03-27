namespace TradeSystem.Core.Exeptions
{
    public class NotEmployeeException : Exception
    {
        public NotEmployeeException() { }

        public NotEmployeeException(string message)
            :base() { }        
    }
}
