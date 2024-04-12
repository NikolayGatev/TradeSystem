namespace TradeSystem.Core.Models.Employees
{
    public class ClientsDataQueryServiceModel
    {
        public ClientsDataQueryServiceModel()
        {
            this.ClientsData = new HashSet<DataOfClientServiseModelForCheching>();
        }

        public int TotalClientsDataCount { get; set; }

        public IEnumerable<DataOfClientServiseModelForCheching> ClientsData { get; set; }
    }
}
