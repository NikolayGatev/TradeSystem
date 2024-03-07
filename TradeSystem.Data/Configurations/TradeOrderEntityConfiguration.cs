using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations
{
    public class TradeOrderEntityConfiguration : IEntityTypeConfiguration<TradeOrder>
    {
        public void Configure(EntityTypeBuilder<TradeOrder> builder)
        {
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
