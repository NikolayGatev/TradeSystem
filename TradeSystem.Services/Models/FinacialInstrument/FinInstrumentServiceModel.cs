namespace TradeSystem.Core.Models.FinacialInstrument
{
    public class FinInstrumentServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public uint? SharesHeld { get; set; }

        public uint? SumOfAllOrdersSell { get; set; }
    }
}