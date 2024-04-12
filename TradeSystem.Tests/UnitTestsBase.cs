using Moq;
using Moq.EntityFrameworkCore;
using TradeSystem.Core.Contracts;
using TradeSystem.Data;
using TradeSystem.Data.Common;
using TradeSystem.Data.Models;
using TradeSystem.Data.Repositories;

namespace TradeSystem.Tests
{
    public class UnitTestsBase
    {
        protected List<Client> listClient;
        protected List<Order> listOrder;
        protected List<ClientFinancialInstrument> listClientFinancialInstrument;
        protected List<FinancialInstrument> listFinancialInstrument;


        protected Mock<IDeletableEntityRepository<Client>> mockRepoClient;
        protected Mock<IDeletableEntityRepository<Order>> mockRepoOrder;
        protected Mock<IDeletableEntityRepository<ClientFinancialInstrument>> mockRepoClientFinancialInstrument;
        protected Mock<IDeletableEntityRepository<FinancialInstrument>> mockRepoFinancialInstrument;

        protected Mock<IClientService> mockClientService;

        [OneTimeSetUp] 
        public void SetUpBase()
        {
            mockClientService = new Mock<IClientService>();

            listClient = new List<Client>()
            {
                new Client()
            {
                Id = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                IsIndividual = true,
                Balance = 50000,
                BlockedSum = 0,
            },
                new Client()
            {
                Id = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                IsIndividual = false,
                Balance = 70000,
                BlockedSum = 0,
            },
        };
            mockRepoClient = new Mock<IDeletableEntityRepository<Client>>();


            listOrder = new List<Order>()
            {
                new Order()
            {
                Id = Guid.Parse("98807339-c1a5-4c2e-81f2-7c15e493bec8"),
                IsBid = true,
                InitialVolume = 100,
                ActiveVolume = 0,
                Price = 10,
                FinancialInstrumentId = 1,
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                IsDeleted = true,
            },
                new Order()
            {
                Id = Guid.Parse("4a2715ef-7648-4369-ba0e-2f9bdd3d79b3"),
                IsBid = true,
                InitialVolume = 200,
                ActiveVolume = 0,
                Price = 10,
                FinancialInstrumentId = 2,
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                IsDeleted = true,
            },
                new Order()
            {
                Id = Guid.Parse("9edba98d-8ee3-4e2e-8c38-dd18477f5a81"),
                IsBid = false,
                InitialVolume = 100,
                ActiveVolume = 100,
                Price = 10,
                FinancialInstrumentId = 1,
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca")
            },
                new Order()
            {
                Id = Guid.Parse("f74db81b-3dc9-4841-8bd0-6029600200aa"),
                IsBid = false,
                InitialVolume = 200,
                ActiveVolume = 200,
                Price = 5,
                FinancialInstrumentId = 2,
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
            },
                new Order()
            {
                Id = Guid.Parse("55a73acc-6a01-43bc-b8d1-f81cd707f335"),
                IsBid = false,
                InitialVolume = 100,
                ActiveVolume = 0,
                Price = 10,
                FinancialInstrumentId = 1,
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                IsDeleted = true,
            },
                new Order()
            {
                Id = Guid.Parse("417d6699-1b1d-45c9-9ebb-27fbef1dae84"),
                IsBid = true,
                InitialVolume = 200,
                ActiveVolume = 0,
                Price = 10,
                FinancialInstrumentId = 2,
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                IsDeleted = true,
            },
                new Order()
            {
                Id = Guid.Parse("c0cfddfe-946d-40b5-9911-e87f4c3598be"),
                IsBid = false,
                InitialVolume = 100,
                ActiveVolume = 100,
                Price = 10,
                FinancialInstrumentId = 3,
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18")
            },
                new Order()
            {
                Id = Guid.Parse("b5cf01f7-2fae-402e-b8f5-20b0ffcf4fac"),
                IsBid = false,
                InitialVolume = 200,
                ActiveVolume = 200,
                Price = 5,
                FinancialInstrumentId = 4,
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
            },
        };
            mockRepoOrder = new Mock<IDeletableEntityRepository<Order>>();

            listClientFinancialInstrument = new List<ClientFinancialInstrument>()
            {
                new ClientFinancialInstrument()
            {
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                FinancialInstrumentId = 1,
                Volume = 5000
            },
                new ClientFinancialInstrument()
            {
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                FinancialInstrumentId = 2,
                Volume = 6000
            },
                new ClientFinancialInstrument()
            {
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                FinancialInstrumentId = 3,
                Volume = 3000,
            },
                new ClientFinancialInstrument()
            {
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                FinancialInstrumentId = 4,
                Volume = 7000,
            },
        };
            mockRepoClientFinancialInstrument = new Mock<IDeletableEntityRepository<ClientFinancialInstrument>>();

            listFinancialInstrument = new List<FinancialInstrument>()
            {
                new FinancialInstrument()
            {
                Id = 1,
                Name = "BULGARIAN STOCK EXCHANGE",
                Description = "Financial and insurance activities",
                ISIN = "BG1100016978",
            },
                new FinancialInstrument()
            {
                Id = 2,
                Name = "SOPHARMA",
                Description = "Manufacturing",
                ISIN = "BG11SOSOBT18",
            },
                new FinancialInstrument()
            {
                Id = 3,
                Name = "INDUSTRIAL HOLDING BULGARIA",
                Description = "Financial and insurance activities",
                ISIN = "BG1100019980",
            },
                new FinancialInstrument()
            {
                Id = 4,
                Name = "SHELLY GROUP",
                Description = "Financial and insurance activities",
                ISIN = "BG1100003166",
            },
        };
            mockRepoFinancialInstrument = new Mock<IDeletableEntityRepository<FinancialInstrument>>();
            
        }
    }
}
