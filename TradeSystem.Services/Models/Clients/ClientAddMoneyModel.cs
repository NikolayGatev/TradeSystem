using System.ComponentModel.DataAnnotations;
using static TradeSystem.Common.EntityValidationConstants.OrderAndTradesConstants;
using static TradeSystem.Common.MessageConstants;

namespace TradeSystem.Core.Models.Clients
{
    public class ClientAddMoneyModel
    {
        public Guid Id { get; set; }
                
        public decimal Balance { get; set; }

        [Display(Name = "Blocked sum")]

        public decimal BlockedSum { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), PriceMinLegnth, DepozitMax,
            ConvertValueInInvariantCulture = true
            , ErrorMessage = PriceValue)]
        [Display(Name = "Deposit sum")]

        public decimal AddedSum { get; set; } = 1;


    }
}
