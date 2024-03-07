using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .Property(h => h.CreatedOn)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
