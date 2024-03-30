namespace TradeSystem.Core.Exeptions
{
    public class NonEmployeeException : Exception
    {
        public NonEmployeeException() { }

        public NonEmployeeException(string message)
            :base() { }        
    }
}
