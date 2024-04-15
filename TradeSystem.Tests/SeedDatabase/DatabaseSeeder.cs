using System.Diagnostics;
using System.Diagnostics.Metrics;
using TradeSystem.Data;
using TradeSystem.Data.Models;

namespace TradeSystem.Tests.SeedDatabase
{
    public static class DatabaseSeeder
    {
        public static ClientFinancialInstrument ClientFinInstr1;
        public static ClientFinancialInstrument ClientFinInstr2;
        public static ClientFinancialInstrument ClientFinInstr3;
        public static ClientFinancialInstrument ClientFinInstr4;
        public static ClientFinancialInstrument ClientFinInstr5;

        public static FinancialInstrument FinancialInstrument1;
        public static FinancialInstrument FinancialInstrument2;
        public static FinancialInstrument FinancialInstrument3;
        public static FinancialInstrument FinancialInstrument4;

        public static Client Individual;
        public static Client Corporative;

        public static Order Order1;
        public static Order Order2;
        public static Order Order3;
        public static Order Order4;
        public static Order Order5;
        public static Order Order6;
        public static Order Order7;
        public static Order Order8;

        public static ApplicationUser User1;
        public static ApplicationUser User2;
        public static ApplicationUser User3;
        public static ApplicationUser User4;

        public static Country Country1;
        public static Country Country2;
        public static Country Country3;

        public static DataOfCorporateveClient Client1;
        public static DataOfIndividualClient Client2;

        public static Division Division1;
        public static Division Division2;
        public static Division Division3;

        public static Employee Employee1;
        public static Employee Employee2;

        public static Town Town1;

        public static Trade Trade1;
        public static Trade Trade2;

        public static TradeOrder TradeOrder1;
        public static TradeOrder TradeOrder2;
        public static TradeOrder TradeOrder3;
        public static TradeOrder TradeOrder4;

        public static void SeedDatabase(TradeSystemDbContext dbContext)
        {
            ////// Seed ClientFinancialInstrument
            ClientFinInstr1 = new ClientFinancialInstrument()
            {
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                FinancialInstrumentId = 1,
                Volume = 5000
            };

            ClientFinInstr2 = new ClientFinancialInstrument()
            {
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                FinancialInstrumentId = 2,
                Volume = 6000
            };

            ClientFinInstr3 = new ClientFinancialInstrument()
            {
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                FinancialInstrumentId = 3,
                Volume = 3000,
            };

            ClientFinInstr4 = new ClientFinancialInstrument()
            {
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                FinancialInstrumentId = 4,
                Volume = 7000,
            };
            dbContext.ClientFinancialInstruments.Add(ClientFinInstr1);
            dbContext.ClientFinancialInstruments.Add(ClientFinInstr2);
            dbContext.ClientFinancialInstruments.Add(ClientFinInstr3);
            dbContext.ClientFinancialInstruments.Add(ClientFinInstr4);

            ///////// Seed FinancialInstrument
            FinancialInstrument1 = new FinancialInstrument()
            {
                Id = 1,
                Name = "BULGARIAN STOCK EXCHANGE",
                Description = "Financial and insurance activities",
                ISIN = "BG1100016978",
            };

            FinancialInstrument2 = new FinancialInstrument()
            {
                Id = 2,
                Name = "SOPHARMA",
                Description = "Manufacturing",
                ISIN = "BG11SOSOBT18",
            };

            FinancialInstrument3 = new FinancialInstrument()
            {
                Id = 3,
                Name = "INDUSTRIAL HOLDING BULGARIA",
                Description = "Financial and insurance activities",
                ISIN = "BG1100019980",
            };

            FinancialInstrument4 = new FinancialInstrument()
            {
                Id = 4,
                Name = "SHELLY GROUP",
                Description = "Financial and insurance activities",
                ISIN = "BG1100003166",
            };
            dbContext.FinancialInstruments.Add(FinancialInstrument1);
            dbContext.FinancialInstruments.Add(FinancialInstrument2);
            dbContext.FinancialInstruments.Add(FinancialInstrument3);
            dbContext.FinancialInstruments.Add(FinancialInstrument4);

            ///// Seed Clients
            Individual = new Client()
            {
                Id = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                IsIndividual = true,
                Balance = 50000,
                BlockedSum = 0,
            };

            Corporative = new Client()
            {
                Id = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                IsIndividual = false,
                Balance = 70000,
                BlockedSum = 0,
            };
            dbContext.Clients.Add(Individual);
            dbContext.Clients.Add(Corporative);

            // Seed Orders
            Order1 = new Order()
            {
                Id = Guid.Parse("98807339-c1a5-4c2e-81f2-7c15e493bec8"),
                IsBid = true,
                InitialVolume = 100,
                ActiveVolume = 0,
                Price = 10,
                FinancialInstrumentId = 1,
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                IsDeleted = true,
            };

            Order2 = new Order()
            {
                Id = Guid.Parse("4a2715ef-7648-4369-ba0e-2f9bdd3d79b3"),
                IsBid = true,
                InitialVolume = 200,
                ActiveVolume = 0,
                Price = 10,
                FinancialInstrumentId = 2,
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
                IsDeleted = true,
            };

            Order3 = new Order()
            {
                Id = Guid.Parse("9edba98d-8ee3-4e2e-8c38-dd18477f5a81"),
                IsBid = false,
                InitialVolume = 100,
                ActiveVolume = 100,
                Price = 10,
                FinancialInstrumentId = 1,
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca")
            };

            Order4 = new Order()
            {
                Id = Guid.Parse("f74db81b-3dc9-4841-8bd0-6029600200aa"),
                IsBid = false,
                InitialVolume = 200,
                ActiveVolume = 200,
                Price = 5,
                FinancialInstrumentId = 2,
                ClientId = Guid.Parse("37d8ee74-9ead-4307-bd5c-6ad5f824edca"),
            };

            Order5 = new Order()
            {
                Id = Guid.Parse("55a73acc-6a01-43bc-b8d1-f81cd707f335"),
                IsBid = false,
                InitialVolume = 100,
                ActiveVolume = 0,
                Price = 10,
                FinancialInstrumentId = 1,
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                IsDeleted = true,
            };

            Order6 = new Order()
            {
                Id = Guid.Parse("417d6699-1b1d-45c9-9ebb-27fbef1dae84"),
                IsBid = false,
                InitialVolume = 200,
                ActiveVolume = 0,
                Price = 10,
                FinancialInstrumentId = 2,
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
                IsDeleted = true,
            };

            Order7 = new Order()
            {
                Id = Guid.Parse("c0cfddfe-946d-40b5-9911-e87f4c3598be"),
                IsBid = false,
                InitialVolume = 100,
                ActiveVolume = 100,
                Price = 10,
                FinancialInstrumentId = 3,
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18")
            };

            Order8 = new Order()
            {
                Id = Guid.Parse("b5cf01f7-2fae-402e-b8f5-20b0ffcf4fac"),
                IsBid = false,
                InitialVolume = 200,
                ActiveVolume = 200,
                Price = 5,
                FinancialInstrumentId = 4,
                ClientId = Guid.Parse("660cb0ec-82b4-462c-8a0f-fdb6bf232f18"),
            };
            dbContext.Orders.Add(Order1);
            dbContext.Orders.Add(Order2);
            dbContext.Orders.Add(Order3);
            dbContext.Orders.Add(Order4);
            dbContext.Orders.Add(Order5);
            dbContext.Orders.Add(Order6);
            dbContext.Orders.Add(Order7);
            dbContext.Orders.Add(Order8);

            // Seed ApplicationUser

            User1 = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.comm",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com"
            };

            User2 = new ApplicationUser()
            {
                Id = "4a6e690e-7d13-4c7e-88e9-8d7f10f456bb",
                UserName = "employee@gmail.com",
                NormalizedUserName = "employee@gmail.com",
                Email = "employee@gmail.com",
                NormalizedEmail = "employee@gmail.com"
            };

            User3 = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "individual@gmail.com",
                NormalizedUserName = "individual@gmail.com",
                Email = "individual@gmail.com",
                NormalizedEmail = "individual@gmail.com"
            };

            User4 = new ApplicationUser()
            {
                Id = "7586d7f6-e626-4e06-999e-7c977382c6de",
                UserName = "corporative@gmail.com",
                NormalizedUserName = "corporative@gmail.com",
                Email = "corporative@gmail.com",
                NormalizedEmail = "corporative@gmail.com"
            };
            dbContext.Users.Add(User1);
            dbContext.Users.Add(User2);
            dbContext.Users.Add(User3);
            dbContext.Users.Add(User4);

            // Seed Counrties

            Country1 = new Country()
            {
                Id = 1,
                Name = "Bulgaria",
            };

            Country2 = new Country()
            {
                Id = 2,
                Name = "Italy",
            };

            Country3 = new Country()
            {
                Id = 3,
                Name = "Germany",
            };
            dbContext.Countries.Add(Country1);
            dbContext.Countries.Add(Country2);
            dbContext.Countries.Add(Country3);

            // Seed Data Of Corporatve Client
            Client1 = new DataOfCorporateveClient()
            {
                Id = Guid.Parse("3c2a6e70-1466-482c-8908-21f1ea3b5eb4"),
                DataChecking = Data.Models.Enumerations.ResultFromChecking.Accepted,
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
            dbContext.DataOfCorporateClients.Add(Client1);

            //Seed Data Of iNdividual Client

            Client2 = new DataOfIndividualClient()
            {
                Id = Guid.Parse("f316a20f-0bfa-4412-81a1-50bcb6562bc0"),
                DataChecking = Data.Models.Enumerations.ResultFromChecking.Accepted,
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
            dbContext.DataOfIndividualClients.Add(Client2);

            // Seed Divisions
            Division1 = new Division()
            {
                Id = 1,
                Name = "Compliance"
            };

            Division2 = new Division()
            {
                Id = 2,
                Name = "Authority Traders"
            };

            Division3 = new Division()
            {
                Id = 3,
                Name = "Backoffice"
            };
            dbContext.Divisions.Add(Division1);
            dbContext.Divisions.Add(Division2);
            dbContext.Divisions.Add(Division3);

            // Seed Employees
            Employee1 = new Employee()
            {
                Id = Guid.Parse("67524a1e-2595-440e-a6d2-103aaf179a08"),
                IsApproved = true,
                ApplicationUserId = "dea12856-c198-4129-b3f3-b893d8395082",
                FirstName = "Admin",
                LastName = "Administrator",
                PhoneNumber = "1234567890",
                DivisionId = 1,
            };

            Employee2 = new Employee()
            {
                Id = Guid.Parse("4bcfd374-c252-4193-8bfe-5e84379984cf"),
                IsApproved = true,
                ApplicationUserId = "4a6e690e-7d13-4c7e-88e9-8d7f10f456bb",
                FirstName = "Employee",
                LastName = "Employeev",
                PhoneNumber = "2234567890",
                DivisionId = 1,
            };
            dbContext.Employees.Add(Employee1);
            dbContext.Employees.Add(Employee2);

            // Seed Towns
            Town1 = new Town()
            {
                Id = 1,
                Name = "Sofia",
                CountryId = 1,
            };
            dbContext.Towns.Add(Town1);

            //Seed Trades
            Trade1 = new Trade()
            {
                Id = Guid.Parse("c4824a81-6996-41a6-bf31-95dc69266175"),
                Volume = 100,
                Price = 10,
                FinancialInstrumentId = 1
            };

            Trade2 = new Trade()
            {
                Id = Guid.Parse("7dcb44f7-26af-4ee0-96f3-fe9ea161823f"),
                Volume = 200,
                Price = 10,
                FinancialInstrumentId = 2
            };
            dbContext.Trades.Add(Trade1);
            dbContext.Trades.Add(Trade2);

            // Seed TradeOrders
            TradeOrder1 = new TradeOrder()
            {
                TradeId = Guid.Parse("c4824a81-6996-41a6-bf31-95dc69266175"),
                OrderId = Guid.Parse("55a73acc-6a01-43bc-b8d1-f81cd707f335"),
                Volume = 100,
            };

            TradeOrder2 = new TradeOrder()
            {
                TradeId = Guid.Parse("c4824a81-6996-41a6-bf31-95dc69266175"),
                OrderId = Guid.Parse("98807339-c1a5-4c2e-81f2-7c15e493bec8"),
                Volume = 100,
            };

            TradeOrder3 = new TradeOrder()
            {
                TradeId = Guid.Parse("7dcb44f7-26af-4ee0-96f3-fe9ea161823f"),
                OrderId = Guid.Parse("4a2715ef-7648-4369-ba0e-2f9bdd3d79b3"),
                Volume = 100,
            };

            TradeOrder4 = new TradeOrder()
            {
                TradeId = Guid.Parse("7dcb44f7-26af-4ee0-96f3-fe9ea161823f"),
                OrderId = Guid.Parse("417d6699-1b1d-45c9-9ebb-27fbef1dae84"),
                Volume = 100,
            };
            dbContext.TradeOrders.Add(TradeOrder1);
            dbContext.TradeOrders.Add(TradeOrder2);
            dbContext.TradeOrders.Add(TradeOrder3);
            dbContext.TradeOrders.Add(TradeOrder4);

            dbContext.SaveChangesAsync();
        }
    }
}
