﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TradeSystem.Common.EntityValidationConstants.CorporativeClientConstants;
using static TradeSystem.Common.GeneralApplicationConstants;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class contains the submitted information about each corporate client.
    /// </summary>
    public class DataOfCorporateveClient : DataOfClient
    {        
        [Required]
        [MaxLength(MaxLengthCorporationName)]

        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxLengthNationalIdentityNumber)]

        public string NationalIdentityNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxLengthLegalForm)]

        public string LegalForm { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxLengthNameOfRepresentative)]

        public String NameOfRepresentative { get; set; } = String.Empty;

        [ForeignKey(nameof(EmployeeId))]

        public virtual Employee? Employee { get; set; }

        public Guid? EmployeeId { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUserId))]

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        [Required]

        public string ApplicationUserId { get; set; } = null!;

        [ForeignKey(nameof(ClientId))]

        public virtual Client? Client { get; set; }

        public Guid? ClientId { get; set; }       
    }
}