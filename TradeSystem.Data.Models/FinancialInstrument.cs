using System.ComponentModel.DataAnnotations;
using static TradeSystem.Common.EntityValidationConstants.FinancialInstrumentonstants;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class contains information about the financial instrument that are traded.
    /// </summary>
    public class FinancialInstrument
    {
        public FinancialInstrument()
        {
            this.OwnersOfThisInstruments = new HashSet<ClientFinancialInstrument>();
        }
        [Key]

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthName)]

        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxLengthDescription)]

        public string Description { get; set; } = string.Empty;

        [Required]
        [MaxLength(ISINLength)]

        public string ISIN { get; set; } = string.Empty;

        public virtual ICollection<ClientFinancialInstrument> OwnersOfThisInstruments { get; set; } = null!;
    }
}