using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations.Seed
{
    internal class DataOfIndividualClientEntityConfiguration : IEntityTypeConfiguration<DataOfIndividualClient>
    {
        public void Configure(EntityTypeBuilder<DataOfIndividualClient> builder)
        {
            builder.HasData(GenerateIndividualClients());
        }

        private DataOfIndividualClient[] GenerateIndividualClients()
        {
            ICollection<DataOfIndividualClient> clients = new HashSet<DataOfIndividualClient>();

            DataOfIndividualClient client;

            client = new DataOfIndividualClient()
            {
                Id = Guid.Parse("21bbf6eb-0d93-460c-ab6f-c1530b16e97d"),
                NationalityId = 1,
                ApplicationUserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                Address = "130a7006-f51d-4a2c-8796-92b0438a1293",
                PhoneNumber = "1234456",
                TownId = 1,
                CreatedOn = DateTime.Now,
                FirstName = "Petko",
                Surname = "Client",
                DateOfBirth = new DateTime(2000, 1, 1),
            };
            clients.Add(client);
            return clients.ToArray();
        }
    }
}
