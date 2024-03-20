using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using TradeSystem.Core.Attributes;
using static TradeSystem.Common.EntityValidationConstants.IndividualClientConstants;
using static TradeSystem.Common.GeneralApplicationConstants;
using static TradeSystem.Common.MassegeConstants;
namespace TradeSystem.Core.Models.Clients
{
    public class IndividualDataClentFormModel
    {        

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthIndividualName, MinimumLength = MinLengthIndividualName
            ,ErrorMessage = LengthMessage)]

        public string FirstName { get; set; } = string.Empty;

        [StringLength(MaxLengthIndividualName, MinimumLength = MinLengthIndividualName
            ,ErrorMessage = LengthMessage)]

        public string? SecondName { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthIndividualName, MinimumLength = MinLengthIndividualName
            ,ErrorMessage = LengthMessage)]

        public string Surname { get; set; } = string.Empty;

        [Display(Name = "Nationality")]

        public int NationalityId { get; set; }

        public IEnumerable<CountryServiceModel>? Nationalities { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Address(district/ str./ number/ floor/ flat)")]

        public string Address { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Address(contains only letters and space")]

        public string Town { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthPhoneNumber, MinimumLength = MinLengthPhoneNumber,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Phone number")]
        [Phone]

        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [IsAdult(ErrorMessage = HasBeAdult)]
        [Display(Name = "Date of Birth(M.d.yyyy)")]

        public string DateOfBirth { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthNationalIdentityNumber, MinimumLength = MinLengthNationalIdentityNumber
            ,ErrorMessage = LengthMessage)]
        [Display(Name = "National Identity Number")]

        public string NationalIdentityNumber { get; set; } = string.Empty;

        [CorectFile(MaxSizeFile, ErrorMessage = FileLength)]
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Upload ID document")]

        public IFormFile File { get; set; } = null!;
    }
}
