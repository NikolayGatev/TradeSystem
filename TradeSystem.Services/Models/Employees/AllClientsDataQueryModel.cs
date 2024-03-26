using System.ComponentModel.DataAnnotations;
using TradeSystem.Core.Models.Clients;
using TradeSystem.Data.Models.Enumerations;

namespace TradeSystem.Core.Models.Employees
{
    public class AllClientsDataQueryModel
    {
        public AllClientsDataQueryModel()
        {
            this.Nationalities = new List<string>();
            this.Statuses = new List<string>();
            this.ClientsData = new HashSet<DataOfClientServiseModelForCheching>();
            this.TypeOfClients = new List<string>();
        }

        public int LinePerPage { get; set; } = 3;

        public string Nationality { get; set; } = null!;

        [Display(Name = "Search by text")]

        public string SearchTerm { get; init; } = null!;

        public string TypeOfClient { get; set; } = null!;

        public string Status { get; set; } = null!;

        public int CurrentPage { get; init; } = 1;

        public int TotalDataCount { get; set; }

        public IEnumerable<string> Nationalities { get; set; }

        public IEnumerable<string> Statuses { get; set; }

        public IEnumerable<string> TypeOfClients { get; set; }

        public IEnumerable<DataOfClientServiseModelForCheching> ClientsData { get; set; }
    }
}
