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
    public class DataOfIndividualClientEntityConfiguration : IEntityTypeConfiguration<DataOfIndividualClient>
    {
        public void Configure(EntityTypeBuilder<DataOfIndividualClient> builder)
        {
            builder
                .Property(h => h.CreatedOn)
                .HasDefaultValue("GETUTCDATE");
        }
    }
}
