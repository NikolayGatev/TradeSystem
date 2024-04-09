namespace TradeSystem.Core.Models.Orders
{
    public class OrderDetailsServiceModel : OrderFormModel
    {
        public Guid Id { get; set; }

        public string FinancialInstrumentName { get; set; } = null!;

        public uint UnfulfilledVolume { get; set; }

        public bool IsDelete { get; set; }

        public Guid? ClientId { get; set; }
    }
}
