using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations
{
    public class DataOfCorporativeClientEntityConfiguration : IEntityTypeConfiguration<DataOfCorporateveClient>
    {
        public void Configure(EntityTypeBuilder<DataOfCorporateveClient> builder)
        {
            builder
                .Property(h => h.CreatedOn)
                .HasDefaultValueSql("GETUTCDATE()");
            builder
                .HasOne(n => n.Nationality)
                .WithMany(c => c.CorporativeClients)
                .HasForeignKey(n => n.NationalityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
