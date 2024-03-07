using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations.Seed
{
    public class DivisionEntityConfiguration : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> builder)
        {
            builder.HasData(GenerateDivisions());
        }

        private Division[] GenerateDivisions()
        {
            ICollection<Division> divisions = new HashSet<Division>();

            Division division;

            division = new Division()
            {
                Id = 1,
                Name = "Compliance"
            };
            divisions.Add(division);

            division = new Division()
            {
                Id = 2,
                Name = "Authority Traders"
            };
            divisions.Add(division);

            division = new Division()
            {
                Id = 3,
                Name = "Backoffice"
            };
            divisions.Add(division);

            return divisions.ToArray();
        }
    }
}