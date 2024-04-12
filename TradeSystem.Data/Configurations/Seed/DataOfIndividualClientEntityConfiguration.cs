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
                Id = Guid.Parse("f316a20f-0bfa-4412-81a1-50bcb6562bc0"),
                DataChecking = Models.Enumerations.ResultFromChecking.Accepted,
                EmployeeId = Guid.Parse("67524a1e-2595-440e-a6d2-103aaf179a08"),
                NationalityId = 1,
                ApplicationUserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                Address = "Ovcha Kupel 58",
                PhoneNumber = "1234456",
                TownId = 1,
                CreatedOn = DateTime.Now,
                AuthorisedOn = DateTime.Now,
                FirstName = "Individual",
                Surname = "Invidualov",
                NationalIdentityNumber = "BC1245643566",
                DateOfBirth = new DateTime(2000, 1, 1),
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca")
            };
            clients.Add(client);
            return clients.ToArray();
        }
    }
}
