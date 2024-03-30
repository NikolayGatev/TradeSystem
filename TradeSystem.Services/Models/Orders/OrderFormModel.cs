using System.ComponentModel.DataAnnotations;
using static TradeSystem.Common.EntityValidationConstants.OrderAndTradesConstants;
using static TradeSystem.Common.MassegeConstants;

namespace TradeSystem.Core.Models.Orders
{
    public class OrderFormModel
    {
        public OrderFormModel()
        {
            this.FinancialInstruments = new List<FinInstrumentServiceModel>();
        }

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Buy or Sell")]

        public bool IsBid { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Volume for executing")]
        [Range(VolumeMinLegnth, VolumeMaxLegnth)]

        public uint InitialVolume { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), PriceMinLegnth, PriceMaxLegnth
            , ErrorMessage = PriceValue)]
        [Display(Name = "Price Per Lot")]

        public decimal Price { get; set; }

        [Display(Name = "Financial instrument")]

        public int FinancialInstrumentId { get; set; }

        public IEnumerable<FinInstrumentServiceModel> FinancialInstruments { get; set; }
    }
}
