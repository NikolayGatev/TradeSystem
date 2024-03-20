using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TradeSystem.Data.Models;
using static TradeSystem.Common.GeneralApplicationConstants;
using static TradeSystem.Common.MassegeConstants;

namespace TradeSystem.Core.Models.Employees
{
    public class EmployeeFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthIndividualName, MinimumLength = MinLengthIndividualName
            ,ErrorMessage = LengthMessage)]

        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthIndividualName, MinimumLength = MinLengthIndividualName
            ,ErrorMessage = LengthMessage)]

        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthPhoneNumber, MinimumLength = MinLengthPhoneNumber,
            ErrorMessage = LengthMessage)]
        [Display(Name = "Phone number")]
        [Phone]

        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Division")]

        public int DivisionId { get; set; }

        public IEnumerable<DivisionServiceModel>? Divisions { get; set; }
    }
}
