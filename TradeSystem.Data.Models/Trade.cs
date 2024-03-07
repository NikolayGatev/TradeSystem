using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static TradeSystem.Common.EntityValidationConstants.OrderAndTradesConstants;


namespace TradeSystem.Data.Models
{
    public class Trade
    {
        /// <summary>
        /// This class contains informations about each trade.
        /// </summary>
        public Trade()
        {
            this.TradeOrders = new List<TradeOrder>();
        }
        [Key]

        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public uint Volume { get; set; }

        [Precision(MaxNumberOfDigits, FloatingPointPrecision)]

        public decimal Price { get; set; }

        public int FinancialInstrumentId { get; set; }

        [Required]
        [ForeignKey(nameof(FinancialInstrumentId))]

        public virtual FinancialInstrument FinancialInstrument { get; set; } = null!;        

        public virtual ICollection<TradeOrder> TradeOrders { get; set; } = null!;
    }
}