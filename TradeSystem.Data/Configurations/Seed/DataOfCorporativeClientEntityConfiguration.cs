using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations.Seed
{
    internal class DataOfCorporativeClientEntityConfiguration : IEntityTypeConfiguration<DataOfCorporateveClient>
    {
        public void Configure(EntityTypeBuilder<DataOfCorporateveClient> builder)
        {
            builder.HasData(GenerateInfoCorporativenClient());
        }

        private DataOfCorporateveClient[] GenerateInfoCorporativenClient()
        {
            ICollection<DataOfCorporateveClient> clients = new HashSet<DataOfCorporateveClient>();

            DataOfCorporateveClient client;

            client = new DataOfCorporateveClient()
            {
                Id = Guid.Parse("3c2a6e70-1466-482c-8908-21f1ea3b5eb4"),
                DataChecking = Models.Enumerations.ResultFromChecking.Accepted,
                EmployeeId = Guid.Parse("4bcfd374-c252-4193-8bfe-5e84379984cf"),
                NationalityId = 1,
                ApplicationUserId = "7586d7f6-e626-4e06-999e-7c977382c6de",
                Address = "Krasna Polqna 58",
                PhoneNumber = "3234456",
                TownId = 1,
                CreatedOn = DateTime.Now,
                AuthorisedOn = DateTime.Now,
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                Name = "Corporation",
                NationalIdentityNumber = "6789945435677",
                LegalForm = "EOOD",
                NameOfRepresentative = "Petar petrov",
            };
            clients.Add(client);
            return clients.ToArray();
        }
    }
}
