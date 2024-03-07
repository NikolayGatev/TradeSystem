using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class many-to-many relations between FinancialInstrument and Client,
    /// aand contains information about owners of financial instruments.
    /// </summary>
    public class ClientFinancialInstrument
    {        
        [Required]
        [ForeignKey(nameof(ClientId))]  

        public Client Client { get; set; } = null!;

        public Guid ClientId { get; set; }

        [Required]
        [ForeignKey(nameof(FinancialInstrumentId))]

        public FinancialInstrument FinancialInstrument { get; set; } = null!;

        public int FinancialInstrumentId { get; set; }

        public uint Volume { get; set; }
    }
}
