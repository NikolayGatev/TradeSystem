using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TradeSystem.Common.EntityValidationConstants.IndividualClientConstants;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class contains the submitted infomation about each individual client.
    /// </summary>
    public class DataOfIndividualClient : DataOfClients
    {
        public DataOfIndividualClient()
        {
            this.OtherNationalities = new HashSet<Country>();
        }
        
        [Required]
        [MaxLength(MaxLengthName)]

        public string FirstName { get; set; } = string.Empty;

        [MaxLength(MaxLengthName)]

        public string? SecondName { get; set; }

        [Required]
        [MaxLength(MaxLengthName)]

        public string Surname { get; set; } = string.Empty;

        public ICollection<Country> OtherNationalities { get; set; } = null!;

        [Required]
        [MaxLength(MaxLengthNationalIdentityNumber)]

        public string NationalIdentityNumber { get; set; } = string.Empty;
        
        public DateTime DateOfBirth { get; set; }
    }
}