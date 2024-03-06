﻿using Microsoft.EntityFrameworkCore;
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
        }

        [Key]

        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUserId))]

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        public Guid ApplicationUserId { get; set; }

        public bool IsIndividual { get; set; }

        [ForeignKey(nameof(DataOfIndividualClientId))]

        public virtual DataOfIndividualClient? DataOfIndividualClient { get; set; }

        public Guid? DataOfIndividualClientId { get; set; }

        [ForeignKey(nameof(DataOfCorporateClientId))]

        public virtual DataOfCorporateClient? DataOfCorporateClient { get; set; }

        public Guid? DataOfCorporateClientId { get; set; }

        [Precision(MaxNumberOfDigits,FloatingPointPrecision)]

        public decimal Balance { get; set; }

        public virtual ICollection<DepositedMoney> AllDepositedsMoney { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; } = null!;

        public virtual ICollection<Trade> Trades { get; set; } = null!;
    }
}
