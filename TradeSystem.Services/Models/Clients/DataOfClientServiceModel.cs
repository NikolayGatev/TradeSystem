using System.ComponentModel.DataAnnotations;
using TradeSystem.Data.Models.Enumerations;

namespace TradeSystem.Core.Models.Clients
{
    public class DataOfClientServiceModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        [Required]

        public ResultFromChecking DataChecking { get; set; }

        [Required]
        [Display(Name = "Email")]

        public string ApplicationName { get; set; } = null!;

        [Required]

        public string Nationality { get; set; } = null!;

        public int NationalityId { get; set; }


        [Required]

        public string Address { get; set; } = null!;

        [Required]

        public string Town { get; set; } = null!;

        [Required]

        public string PhoneNumber { get; set; } = null!;

        public string? UrlToIDCart { get; set; } = null!;

        public string? ExtentionIdCardFile { get; set; }

        [Required]

        public string TypeOfClient { get; set; } = null!;

        //Data of individual client

        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        public string? Surname { get; set; }

        [Display(Name = "Date of Birth")]

        public string? DateOfBirth { get; set; } = null!;

        [Display(Name = "National Identity Number")]

        public string? NationalIdentityNumberIndividual { get; set; }

        //Date of corporative client

        public string? Name { get; set; }

        public string? NationalIdentityNumber { get; set; }

        public string? LegalForm { get; set; } = string.Empty;

        public String? NameOfRepresentative { get; set; }
    }
}

