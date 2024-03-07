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
    public class DataOfCorporativeClientEntityConfiguration : IEntityTypeConfiguration<DataOfCorporateveClient>
    {
        public void Configure(EntityTypeBuilder<DataOfCorporateveClient> builder)
        {
            builder
                .Property(h => h.CreatedOn)
                .HasDefaultValue("GETUTCTIME()");
        }
    }
}
