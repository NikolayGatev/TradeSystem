using System.ComponentModel.DataAnnotations;
using TradeSystem.Core.Attributes;
using static TradeSystem.Common.GeneralApplicationConstants;
using static TradeSystem.Common.MassegeConstants;
namespace TradeSystem.Core.Models.Clients
{
    public class IndividualDataClentFormModel : DataOfClientFormModel
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
        
        [Required(ErrorMessage = RequiredMessage)]
        [IsAdult(ErrorMessage = HasBeAdult)]
        [Display(Name = "Date of Birth(M.d.yyyy)")]

        public string DateOfBirth { get; set; } = null!;
    }
}
