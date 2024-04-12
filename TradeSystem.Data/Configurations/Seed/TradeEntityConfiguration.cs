using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations.Seed
{
    internal class TradeEntityConfiguration : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder.HasData(GenrateTrades());
        }

        private Trade[] GenrateTrades()
        {
            ICollection<Trade> trades = new HashSet<Trade>();

            Trade trade;

            trade = new Trade()
            {
                Id = Guid.Parse("c4824a81-6996-41a6-bf31-95dc69266175"),
                Volume = 100,
                Price = 10,
                FinancialInstrumentId = 1                
            };
            trades.Add(trade);

            trade = new Trade()
            {
                Id = Guid.Parse("7dcb44f7-26af-4ee0-96f3-fe9ea161823f"),
                Volume = 200,
                Price = 10,
                FinancialInstrumentId = 2
            };
            trades.Add(trade);

            return trades.ToArray();
        }
    }
}
