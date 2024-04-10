using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TradeSystem.Data.Configurations.Seed;
using TradeSystem.Data.Models;

namespace TradeSystem.Data
{
    public class TradeSystemDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly bool seedDb;

        public TradeSystemDbContext(DbContextOptions<TradeSystemDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
        }

        public DbSet<Employee> Employees { get; set; } = null!;

        public DbSet<Client> Clients { get; set; } = null!;

        public DbSet<Country> Countries { get; set; } = null!;

        public DbSet<DataOfCorporateveClient> DataOfCorporateClients { get; set; } = null!;

        public DbSet<DataOfIndividualClient> DataOfIndividualClients { get; set; } = null!;

        public DbSet<Division> Divisions { get; set; } = null!;

        public DbSet<FinancialInstrument> FinancialInstruments { get; set; } = null!;

        public DbSet<IdentityDocument> IdentityDocuments { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<Town> Towns { get; set; } = null!;

        public DbSet<Trade> Trades { get; set; } = null!;

        public DbSet<TradeOrder> TradeOrders { get; set; } = null!;

        public DbSet<ClientFinancialInstrument> ClientFinancialInstruments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ClientFinancialInstrument>()
                .HasKey(cfi => new {cfi.FinancialInstrumentId, cfi.ClientId});

            builder.ApplyConfiguration(new Configurations.ClientEntityConfiguration());
            builder.ApplyConfiguration(new Configurations.DataOfCorporativeClientEntityConfiguration());
            builder.ApplyConfiguration(new Configurations.DataOfIndividualClientEntityConfiguration());
            builder.ApplyConfiguration(new Configurations.OrderEntityConfiguration());
            builder.ApplyConfiguration(new Configurations.TradeEntityConfiguration());
            builder.ApplyConfiguration(new Configurations.TradeOrderEntityConfiguration());
            builder.ApplyConfiguration(new Configurations.TownEntityConfiguration());

            if (this.seedDb)
            {
                builder.ApplyConfiguration(new DivisionEntityConfiguration());
                builder.ApplyConfiguration(new FinancialInstrumentEntityConfiguration());
                builder.ApplyConfiguration(new EmployeeEntityConfiguration());
                builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
                builder.ApplyConfiguration(new CountryEntityConfiguration());
                builder.ApplyConfiguration(new Configurations.Seed.TownEntityConfiguration());
                builder.ApplyConfiguration(new Configurations.Seed.ClientEntityConfiguration());
                builder.ApplyConfiguration(new ClientFinacialInstrumentEntityConfiguration());
                builder.ApplyConfiguration(new Configurations.Seed.DataOfCorporativeClientEntityConfiguration());
                builder.ApplyConfiguration(new Configurations.Seed.DataOfIndividualClientEntityConfiguration());
                builder.ApplyConfiguration(new Configurations.Seed.OrderEntityConfiguration());
                builder.ApplyConfiguration(new Configurations.Seed.TradeEntityConfiguration());
                builder.ApplyConfiguration(new Configurations.Seed.TradeOrderEntityConfiguration());
            }

            base.OnModelCreating(builder);
        }
    }
}
