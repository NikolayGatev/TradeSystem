using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations.Seed
{
    internal class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder) 
        {
            builder.HasData(GenerateClient());
        }

        private Client[] GenerateClient()
        {
            ICollection<Client> clients = new HashSet<Client>();

            Client client;

            client = new Client()
            {
                Id = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                IsIndividual = true,
                Balance = 50000,
                BlockedSum = 0,
            };
            clients.Add(client);

            client = new Client()
            {
                Id = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                IsIndividual = false,
                Balance = 70000,
                BlockedSum = 0,
            };
            clients.Add(client);
            return clients.ToArray();

        }
    }
}
