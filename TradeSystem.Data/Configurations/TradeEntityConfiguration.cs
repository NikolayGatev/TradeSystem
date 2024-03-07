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
    public class TradeEntityConfiguration : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder
                .Property(b => b.CreatedOn)
                .HasDefaultValue("GETUTCDATE");
        }
    }
}
