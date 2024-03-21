using System.ComponentModel.DataAnnotations;
using TradeSystem.Core.Attributes;

namespace TradeSystem.Core.Models.Clients
{
    public class DataOfIndividualClientServiceModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Email")]

        public string ApplicationName { get; set; } = null!;

        [Required]

        public string Nationality { get; set; } = null!;

        [Required()]
        
        public string FirstName { get; set; } = string.Empty;        

        public string? SecondName { get; set; }

        [Required]

        public string Surname { get; set; } = string.Empty;        

        public int NationalityId { get; set; }

        [Required]

        public string Address { get; set; } = null!;

        [Required]

        public string Town { get; set; } = null!;

        [Required]

        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Display(Name = "Date of Birth")]

        public string DateOfBirth { get; set; } = null!;

        [Required]
        [Display(Name = "National Identity Number")]

        public string NationalIdentityNumber { get; set; } = string.Empty;
        
        public string UrlToIDCart { get; set; } = null!;

        public Guid UserId { get; set; }

        public string ExtentionIdCardFile { get; set; }
    }
}
