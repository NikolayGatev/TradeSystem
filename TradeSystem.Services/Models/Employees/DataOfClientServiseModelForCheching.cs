using System.ComponentModel.DataAnnotations;

namespace TradeSystem.Core.Models.Employees
{
    public class DataOfClientServiseModelForCheching
    {
        public Guid Id { get; set; }

        [Required]

        public Guid UserId { get; set; }

        [Required]

        public Guid? ClientId { get; set; }

        public string DataChecking { get; set; } = null!;

        [Required]
        [Display(Name = "Email")]

        public string ApplicationName { get; set; } = null!;

        [Required]

        public string Nationality { get; set; } = null!;


        [Required]

        public string Address { get; set; } = null!;

        [Required]

        public string PhoneNumber { get; set; } = null!;

        [Required]

        public string TypeOfClient { get; set; } = null!;

        //Data of individual client

        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        public string? Surname { get; set; }

        [Display(Name = "National Identity Number")]

        public string? NationalIdentityNumberIndividual { get; set; }

        //Date of corporative client

        public string? Name { get; set; }

        public string? NationalIdentityNumber { get; set; }

        public string? LegalForm { get; set; } = string.Empty;

        public String? NameOfRepresentative { get; set; }
    }
}
