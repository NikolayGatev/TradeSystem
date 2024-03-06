using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TradeSystem.Common.EntityValidationConstants.DepositedMoneyConstants;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class contains informations about every single feed to an account a client.
    /// </summary>
    public class DepositedMoney
    {
        public Guid Id { get; set; }

        [Precision(MaxNumberOfDigits, FloatingPointPrecision)]

        public decimal Amount { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(ClientId))]

        public Client Client { get; set; } = null!;

        public Guid ClientId { get; set; }
    }
}