using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations.Seed
{
    internal class TradeOrderEntityConfiguration : IEntityTypeConfiguration<TradeOrder>
    {
        public void Configure(EntityTypeBuilder<TradeOrder> builder)
        {
            builder.HasData(GenrateTradeOrders());
        }

        private TradeOrder[] GenrateTradeOrders()
        {
            ICollection<TradeOrder> tradeOrders = new HashSet<TradeOrder>();

            TradeOrder tradeOrder;

            tradeOrder = new TradeOrder()
            {
                TradeId = Guid.Parse("c4824a81-6996-41a6-bf31-95dc69266175"),
                OrderId = Guid.Parse("55a73acc-6a01-43bc-b8d1-f81cd707f335"),
                Volume = 100,
            };
            tradeOrders.Add(tradeOrder);

            tradeOrder = new TradeOrder()
            {
                TradeId = Guid.Parse("c4824a81-6996-41a6-bf31-95dc69266175"),
                OrderId = Guid.Parse("98807339-c1a5-4c2e-81f2-7c15e493bec8"),
                Volume = 100,
            };
            tradeOrders.Add(tradeOrder);

            tradeOrder = new TradeOrder()
            {
                TradeId = Guid.Parse("7dcb44f7-26af-4ee0-96f3-fe9ea161823f"),
                OrderId = Guid.Parse("4a2715ef-7648-4369-ba0e-2f9bdd3d79b3"),
                Volume = 100,
            };
            tradeOrders.Add(tradeOrder);

            tradeOrder = new TradeOrder()
            {
                TradeId = Guid.Parse("7dcb44f7-26af-4ee0-96f3-fe9ea161823f"),
                OrderId = Guid.Parse("417d6699-1b1d-45c9-9ebb-27fbef1dae84"),
                Volume = 100,
            };
            tradeOrders.Add(tradeOrder);

            return tradeOrders.ToArray();
        }
    }
}
