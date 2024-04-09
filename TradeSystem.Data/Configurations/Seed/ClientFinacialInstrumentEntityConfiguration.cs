using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeSystem.Data.Models;

namespace TradeSystem.Data.Configurations.Seed
{
    internal class ClientFinacialInstrumentEntityConfiguration : IEntityTypeConfiguration<ClientFinancialInstrument>
    {
        public void Configure(EntityTypeBuilder<ClientFinancialInstrument> builder)
        {
            builder.HasData(GenerateClientFinInstr());
        }

        private ClientFinancialInstrument[] GenerateClientFinInstr()
        {
            ICollection<ClientFinancialInstrument> clientFinancialInstruments = new HashSet<ClientFinancialInstrument>();

            ClientFinancialInstrument clientFinInstr;

            clientFinInstr = new ClientFinancialInstrument()
            {
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                FinancialInstrumentId = 1,
                Volume = 5000
            };
            clientFinancialInstruments.Add(clientFinInstr);

            clientFinInstr = new ClientFinancialInstrument()
            {
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                FinancialInstrumentId = 2,
                Volume = 6000
            };
            clientFinancialInstruments.Add(clientFinInstr);

            clientFinInstr = new ClientFinancialInstrument()
            {
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                FinancialInstrumentId = 3,
                Volume = 3000,
            };
            clientFinancialInstruments.Add(clientFinInstr);

            clientFinInstr = new ClientFinancialInstrument()
            {
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                FinancialInstrumentId = 4,
                Volume = 7000,
            };
            clientFinancialInstruments.Add(clientFinInstr);

            return clientFinancialInstruments.ToArray();
        }
    }
}
