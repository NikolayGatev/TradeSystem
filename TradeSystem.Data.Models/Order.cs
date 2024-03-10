using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TradeSystem.Data.Common.Base;
using static TradeSystem.Common.EntityValidationConstants.OrderAndTradesConstants;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class contains informations about each order.
    /// </summary>
    public class Order : BaseDeletableModel
    {
        public Order()
        {
            this.TradeOrders = new HashSet<TradeOrder>();
        }
        [Key]

        public Guid Id { get; set; }

        public bool IsBid { get; set; }

        public uint InitialVolume { get; set; }

        public uint ActiveVolume { get; set; }

        [Precision(MaxNumberOfDigits,FloatingPointPrecision)]

        public decimal Price { get; set; }

        public int FinancialInstrumentId { get; set; }

        [Required]
        [ForeignKey(nameof(FinancialInstrumentId))]

        public virtual FinancialInstrument FinancialInstrument { get; set; } = null!;

        public Guid ClientId { get; set; }

        [Required]
        [ForeignKey(nameof(ClientId))]

        public virtual Client Client { get; set; } = null!;

        public virtual ICollection<TradeOrder> TradeOrders { get; set; } = null!;
    }
}