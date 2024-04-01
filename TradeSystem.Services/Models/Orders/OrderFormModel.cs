using System.ComponentModel.DataAnnotations;
using TradeSystem.Core.Models.FinacialInstrument;
using static TradeSystem.Common.EntityValidationConstants.OrderAndTradesConstants;
using static TradeSystem.Common.MessageConstants;

namespace TradeSystem.Core.Models.Orders
{
    public class OrderFormModel : IValidatableObject
    {
        public OrderFormModel()
        {
            this.FinancialInstruments = new List<FinInstrumentServiceModel>();
        }

        [Required(ErrorMessage = RequiredMessage)]

        public decimal Balance { get; set; } = 0;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Buy or Sell")]

        public bool IsBid { get; set; } = true;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Volume for executing")]
        [Range(VolumeMin, VolumeMax)]

        public uint InitialVolume { get; set; } = 0;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), PriceMinLegnth, PriceMaxLegnth,
            ConvertValueInInvariantCulture = true
            , ErrorMessage = PriceValue)]
        [Display(Name = "Price Per Lot")]

        public decimal Price { get; set; } = decimal.Parse(PriceMinLegnth);

        [Display(Name = "Financial instrument with your shares count")]

        public int FinancialInstrumentId { get; set; }

        public IEnumerable<FinInstrumentServiceModel> FinancialInstruments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Balance == 0) 
                    yield return new ValidationResult(ZeroBalance);
            if (this.Balance != 0 
                && Math.Floor(this.Balance / this.Price) < this.InitialVolume
                && this.IsBid) 
                    yield return new ValidationResult(DoNotEnoughMoney);
        }
    }
}
