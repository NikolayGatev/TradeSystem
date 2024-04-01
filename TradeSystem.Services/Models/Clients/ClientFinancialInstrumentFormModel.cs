using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TradeSystem.Data.Models;
using TradeSystem.Core.Models.FinacialInstrument;
using static TradeSystem.Common.EntityValidationConstants.FinancialInstrumentonstants;
using static TradeSystem.Common.MessageConstants;

namespace TradeSystem.Core.Models.Clients
{
    public class ClientFinancialInstrumentFormModel
    {
        [Display(Name = "Client name and clientnumber")]

        public Guid ClientId { get; set; }

        public IEnumerable<ClientsForAddFinancialInstumentFormServiceModel>? Clients { get; set; } = null!;


        public IEnumerable<FinInstrumentServiceModel>? FinancialInstruments { get; set; } = null!;

        public int FinancialInstrumentId { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Volume for executing")]
        [Range(VolumeMin, VolumeMax)]

        public uint Volume { get; set; }
    }
}
