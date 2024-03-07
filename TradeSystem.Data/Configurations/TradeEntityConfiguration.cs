using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations
{
    public class TradeEntityConfiguration : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder
                .Property(b => b.CreatedOn)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
