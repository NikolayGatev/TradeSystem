using System.ComponentModel.DataAnnotations;
using TradeSystem.Core.Models.Enums;

namespace TradeSystem.Core.Models.FinacialInstrument
{
    public class AllFinancialInstrumentsQueryModel
    {
        public AllFinancialInstrumentsQueryModel()
        {
            this.FinInstruments = new HashSet<FinInstrumentDetailsServiceModel>();
        }

        public int FinInstrumentsPerPage { get; } = 3;

        public string ISIN { get; init; } = null!;

        [Display(Name = "Search by text")]

        public string SearchTerm { get; init; } = null!;

        public FinInstrumentsSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalFinInstrumentsCount { get; set; }

        public IEnumerable<string> ISINs { get; set; } = null!;

        public IEnumerable<FinInstrumentDetailsServiceModel> FinInstruments { get; set; }
    }
}
