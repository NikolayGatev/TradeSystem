using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations
{
    public class TradeOrderEntityConfiguration : IEntityTypeConfiguration<TradeOrder>
    {
        public void Configure(EntityTypeBuilder<TradeOrder> builder)
        {
            builder.HasKey(to => new {to.OrderId, to.TradeId});
            builder
                .Property(to => to.CreatedOn)
                .HasDefaultValueSql("GETUTCDATE()");
            builder
                .HasOne(to => to.Order)
                .WithMany(o => o.TradeOrders)
                .HasForeignKey(to => to.OrderId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(to => to.Trade)
                .WithMany(t => t.TradeOrders)
                .HasForeignKey(to => to.TradeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
