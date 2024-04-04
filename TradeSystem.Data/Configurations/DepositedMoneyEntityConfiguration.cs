using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations
{
    public class DepositedMoneyEntityConfiguration : IEntityTypeConfiguration<DepositedMoney>
    {
        public void Configure(EntityTypeBuilder<DepositedMoney> builder)
        {
            builder
                .Property(h => h.CreatedOn)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
