using TradeSystem.Core.Contracts.ModelExtention;

namespace TradeSystem.Core.Models.FinacialInstrument
{
    public class FinInstrumentDetailsServiceModel : FinacialInstrumentFormModel, IFinancialInstrumentModel
    {
        public int Id { get; set; }
    }
}
