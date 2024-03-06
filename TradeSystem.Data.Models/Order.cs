using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TradeSystem.Common.EntityValidationConstants.OrderConstants;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class contains informations about each order.
    /// </summary>
    public class Order
    {
        public Order()
        {
            this.Trades = new Dictionary<Guid, uint>();
        }
        [Key]

        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsBid { get; set; }

        public uint InitialVolume { get; set; }

        public uint ActiveVolume { get; set; }

        [Precision(MaxNumberOfDigits,FloatingPointPrecision)]

        public decimal Price { get; set; }

        public Guid ClientId { get; set; }

        public int FinancialInstrumentId { get; set; }

        [Required]
        [ForeignKey(nameof(FinancialInstrumentId))]

        public virtual FinancialInstrument FinancialInstrument { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(ClientId))]

        public virtual Client Client { get; set; } = null!;

        public virtual IDictionary<Guid, uint> Trades { get; set; } = null!;
    }
}