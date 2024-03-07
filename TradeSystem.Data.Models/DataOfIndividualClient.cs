using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TradeSystem.Common.EntityValidationConstants.IndividualClientConstants;
using static TradeSystem.Common.GeneralApplicationConstants;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class contains the submitted infomation about each individual client.
    /// </summary>
    public class DataOfIndividualClient : DataOfClients
    {      
        
        [Required]
        [MaxLength(MaxLengthIndividualName)]

        public string FirstName { get; set; } = string.Empty;

        [MaxLength(MaxLengthIndividualName)]

        public string? SecondName { get; set; }

        [Required]
        [MaxLength(MaxLengthIndividualName)]

        public string Surname { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(MaxLengthNationalIdentityNumber)]

        public string NationalIdentityNumber { get; set; } = string.Empty;
        
        public DateTime DateOfBirth { get; set; }
    }
}