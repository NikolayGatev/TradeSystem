using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations.Seed
{
    internal class TownEntityConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasData(GenerateTowns());
        }

            private Town[] GenerateTowns()
            {
                ICollection<Town> towns = new HashSet<Town>();

                Town town;

                town = new Town()
                {
                    Id = 1,
                    Name = "Sofia",
                    CountryId = 1,
                };
                towns.Add(town);

                return towns.ToArray();
            }
    }
}
