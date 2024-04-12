using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TradeSystem.Core.Attributes
{
    public class IsAdultAttribute : ValidationAttribute
    {            
        
        private readonly DateTime minimumDate = DateTime.Today.AddYears(-18);             

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var token = value != null ? value.ToString() : string.Empty;

            var isDate = DateTime.TryParseExact(token, TradeSystem.Common.GeneralApplicationConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);
            
            if (value != null && isDate && date <= minimumDate)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult(ErrorMessage);
        }
    }
}
