﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TradeSystem.Data.Common.Base;
using TradeSystem.Data.Models.Enumerations;
using static TradeSystem.Common.GeneralApplicationConstants;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This is abstract class, which contains the submitted information about each client,
    /// and is no different for corporate or individual client.
    /// </summary>
    public abstract class DataOfClient : BaseModel
    {
        [Key]

        public Guid Id { get; set; }

        [Required] 

        public ResultFromChecking DataChecking { get; set; }

        public int NationalityId { get; set; }

        [Required]
        [ForeignKey(nameof(NationalityId))]

        public Country Nationality { get; set; } = null!;             

        [Required]

        public string Address { get; set; } = null!;

        public int TownId { get; set; }

        [Required]
        [ForeignKey(nameof(TownId))]

        public Town Town { get; set; } = null!;

        [Required]
        [MaxLength(MaxLengthPhoneNumber)]

        public string PhoneNumber { get; set; } = null!;
        
        [ForeignKey(nameof(IdentityDocumentId))]

        public virtual IdentityDocument? IdentityDocument { get; set; } 

        public Guid? IdentityDocumentId { get; set; }

        public DateTime? AuthorisedOn { get; set; }
    }
}
