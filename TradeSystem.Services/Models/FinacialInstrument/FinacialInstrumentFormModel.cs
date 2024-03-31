using System.ComponentModel.DataAnnotations;
using static TradeSystem.Common.EntityValidationConstants.FinancialInstrumentonstants;
using static TradeSystem.Common.MessageConstants;

namespace TradeSystem.Core.Models.FinacialInstrument
{
    public class FinacialInstrumentFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthName, MinimumLength = MinLengthName
            , ErrorMessage = LengthMessage)]

        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(MaxLengthDescription, MinimumLength = MinLengthDescription
            , ErrorMessage = LengthMessage)]

        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ISINLength, MinimumLength = ISINLength
            , ErrorMessage = LengthMessage)]

        public string ISIN { get; set; } = string.Empty;
    }
}
