using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations.Seed
{
    internal class AddressEntityConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder) 
        {
            builder.HasData(GenerateAddresses());
        }

        private Address[] GenerateAddresses()
        {
            ICollection<Address> addresses = new HashSet<Address>();

            Address address;

            address = new Address()
            {
                Id = Guid.Parse("130a7006-f51d-4a2c-8796-92b0438a1293"),
                CountryId = 1,
                PostCode = "5300",
                TownId = 1,
                Number = "43",
            };
            addresses.Add(address);
            return addresses.ToArray();
        }
    }
}
