using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations.Seed
{
    internal class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(GenrateOrders());
        }

        private Order[] GenrateOrders()
        {
            ICollection<Order> orders = new HashSet<Order>();

            Order order;

            order = new Order()
            {
                Id = Guid.Parse("98807339-c1a5-4c2e-81f2-7c15e493bec8"),
                IsBid = true,
                InitialVolume = 100,
                ActiveVolume = 0,
                Price = 10,
                FinancialInstrumentId = 1,
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                IsDeleted = true,
            };
            orders.Add(order);

            order = new Order()
            {
                Id = Guid.Parse("4a2715ef-7648-4369-ba0e-2f9bdd3d79b3"),
                IsBid = true,
                InitialVolume = 200,
                ActiveVolume = 0,
                Price = 10,
                FinancialInstrumentId = 2,
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                IsDeleted = true,
            };
            orders.Add(order);

            order = new Order()
            {
                Id = Guid.Parse("9edba98d-8ee3-4e2e-8c38-dd18477f5a81"),
                IsBid = false,
                InitialVolume = 100,
                ActiveVolume = 100,
                Price = 10,
                FinancialInstrumentId = 1,
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca")
            };
            orders.Add(order);

            order = new Order()
            {
                Id = Guid.Parse("f74db81b-3dc9-4841-8bd0-6029600200aa"),
                IsBid = false,
                InitialVolume = 200,
                ActiveVolume = 200,
                Price = 5,
                FinancialInstrumentId = 2,
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
            };
            orders.Add(order);
            
            order = new Order() 
            {
                Id = Guid.Parse("55a73acc-6a01-43bc-b8d1-f81cd707f335"),
                IsBid = false,
                InitialVolume = 100,
                ActiveVolume = 0,
                Price = 10,
                FinancialInstrumentId = 1,
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                IsDeleted = true,
            };
            orders.Add(order);

            order = new Order() 
            {
                Id = Guid.Parse("417d6699-1b1d-45c9-9ebb-27fbef1dae84"),
                IsBid = false,
                InitialVolume = 200,
                ActiveVolume = 0,
                Price = 10,
                FinancialInstrumentId = 2,
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                IsDeleted = true,
            };
            orders.Add(order);

            order = new Order()
            {
                Id = Guid.Parse("c0cfddfe-946d-40b5-9911-e87f4c3598be"),
                IsBid = false,
                InitialVolume = 100,
                ActiveVolume = 100,
                Price = 10,
                FinancialInstrumentId = 3,
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18")
            };
            orders.Add(order);

            order = new Order()
            {
                Id = Guid.Parse("b5cf01f7-2fae-402e-b8f5-20b0ffcf4fac"),
                IsBid = false,
                InitialVolume = 200,
                ActiveVolume = 200,
                Price = 5,
                FinancialInstrumentId = 4,
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
            };
            orders.Add(order);
            return orders.ToArray();
        }
    }
}
