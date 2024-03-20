using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static TradeSystem.Common.GeneralApplicationConstants;

namespace TradeSystem.Core.Attributes
{
    public class CorectFileAttribute : ValidationAttribute
    {
        private readonly int maxLength;

        public CorectFileAttribute(int maxLength)
        {
            this.maxLength = maxLength;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            
            if (file != null)
            {
                 if (file.Length > maxLength || file.Length == 0)
                 {
                     return new ValidationResult(ErrorMessage);
                 }
            }
            

            return ValidationResult.Success;
        }
    }
}
