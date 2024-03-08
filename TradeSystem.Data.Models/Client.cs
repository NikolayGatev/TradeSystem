using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TradeSystem.Common.EntityValidationConstants.ClientsConstants;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class contains information about customer accounts.
    /// </summary>
    public class Client
    {
        public Client()
        {
            this.AllDepositedsMoney = new HashSet<DepositedMoney>();
            this.Orders = new HashSet<Order>();
            this.Trades = new HashSet<Trade>();
            this.FinancialInstruments = new HashSet<ClientFinancialInstrument>();
        }

        [Key]

        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsIndividual { get; set; }

        [Precision(MaxNumberOfDigits,FloatingPointPrecision)]

        public decimal Balance { get; set; }

        public virtual ICollection<DepositedMoney> AllDepositedsMoney { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; } = null!;

        public virtual ICollection<Trade> Trades { get; set; } = null!;

        public virtual ICollection<ClientFinancialInstrument> FinancialInstruments { get; set; } = null!;
    }
}
