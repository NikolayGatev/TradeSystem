using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations.Seed
{
    internal class CountryEntityConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(GenerateCountries());
        }

        private Country[] GenerateCountries()
        {
            ICollection<Country> countries = new HashSet<Country>();

            Country country;

            country = new Country()
            {
                Id = 1,
                Name = "Bulgaria",
            };
            countries.Add(country);

            country = new Country()
            {
                Id = 2,
                Name = "Italy",
            };
            countries.Add(country);

            country = new Country()
            {
                Id = 3,
                Name = "Germany",
            };
            countries.Add(country);

            return countries.ToArray();
        }
    }
}
