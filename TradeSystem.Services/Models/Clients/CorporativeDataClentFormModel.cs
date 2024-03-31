using System.ComponentModel.DataAnnotations;
using static TradeSystem.Common.EntityValidationConstants.CorporativeClientConstants;
using static TradeSystem.Common.GeneralApplicationConstants;
using static TradeSystem.Common.MessageConstants;
namespace TradeSystem.Core.Models.Clients
{
    public class CorporativeDataClentFormModel : DataOfClientFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthCorporationName, MinimumLength = MinLengthCorporationName
            , ErrorMessage = LengthMessage)]

        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthLegalForm, MinimumLength = MinLengthLegalForm
            , ErrorMessage = LengthMessage)]

        public string LegalForm { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthNameOfRepresentative, MinimumLength = MinLengthNameOfRepresentative
            , ErrorMessage = LengthMessage)]

        public String NameOfRepresentative { get; set; } = String.Empty;
    }
}
