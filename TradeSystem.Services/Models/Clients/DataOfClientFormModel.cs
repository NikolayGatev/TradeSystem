using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using TradeSystem.Core.Attributes;
using static TradeSystem.Common.EntityValidationConstants.IndividualClientConstants;
using static TradeSystem.Common.GeneralApplicationConstants;
using static TradeSystem.Common.MessageConstants;

namespace TradeSystem.Core.Models.Clients
{
    public class DataOfClientFormModel
    {
        [Display(Name = "Nationality")]

        public int NationalityId { get; set; }

        public IEnumerable<CountryServiceModel>? Nationalities { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Address(district/ str./ number/ floor/ flat)")]

        public string Address { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Town(contains only letters and space")]

        public string Town { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthPhoneNumber, MinimumLength = MinLengthPhoneNumber,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Phone number")]
        [Phone]

        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthNationalIdentityNumber, MinimumLength = MinLengthNationalIdentityNumber
           , ErrorMessage = LengthMessage)]
        [Display(Name = "National Identity Number")]

        public string NationalIdentityNumber { get; set; } = string.Empty;

        [CorectFile(MaxSizeFile, ErrorMessage = FileLength)]
        [Display(Name = "Upload ID document")]

        public virtual IFormFile? File { get; set; } = null!;
    }
}
