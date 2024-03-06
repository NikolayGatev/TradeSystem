using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static TradeSystem.Common.EntityValidationConstants.CorporativeClientConstants;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class contains the submitted information about each corporate client.
    /// </summary>
    public class DataOfCorporateClient : DataOfClients
    {        
        [Required]
        [MaxLength(MaxLengthName)]

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
    }
}