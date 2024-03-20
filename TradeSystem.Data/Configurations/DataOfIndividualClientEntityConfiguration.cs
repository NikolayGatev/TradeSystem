using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations
{
    public class DataOfIndividualClientEntityConfiguration : IEntityTypeConfiguration<DataOfIndividualClient>
    {
        public void Configure(EntityTypeBuilder<DataOfIndividualClient> builder)
        {
            builder
                .Property(h => h.CreatedOn)
                .HasDefaultValueSql("GETUTCDATE()");

            builder
                .HasOne(c => c.Nationality)
                .WithMany(ic => ic.InvidualClients)
                .HasForeignKey(ic => ic.NationalityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Town)
                .WithMany(t => t.InvidualClients)
                .HasForeignKey(c => c.TownId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
