using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TradeSystem.Data.Configurations;
using TradeSystem.Data.Configurations.Seed;
using TradeSystem.Data.Models;

namespace TradeSystem.Data
{
    public class TradeSystemDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private readonly bool seedDb;

        public TradeSystemDbContext(DbContextOptions<TradeSystemDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
        }

        public DbSet<Administrator> Adminstrators { get; set; } = null!;

        public DbSet<Client> Clients { get; set; } = null!;

        public DbSet<Country> Countries { get; set; } = null!;

        public DbSet<DataOfCorporateveClient> DataOfCorporateClients { get; set; } = null!;

        public DbSet<DataOfIndividualClient> DataOfIndividualClients { get; set; } = null!;

        public DbSet<DepositedMoney> DepositedMoney { get; set; } = null!;

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

            builder.ApplyConfiguration(new ClientEntityConfiguration());
            builder.ApplyConfiguration(new TradeSystem.Data.Configurations.DataOfCorporativeClientEntityConfiguration());
            builder.ApplyConfiguration(new TradeSystem.Data.Configurations.DataOfIndividualClientEntityConfiguration());
            builder.ApplyConfiguration(new DepositedMoneyEntityConfiguration());
            builder.ApplyConfiguration(new OrderEntityConfiguration());
            builder.ApplyConfiguration(new TradeEntityConfiguration());
            builder.ApplyConfiguration(new TradeOrderEntityConfiguration());
            builder.ApplyConfiguration(new TradeSystem.Data.Configurations.TownEntityConfiguration());

            if (this.seedDb)
            {
                builder.ApplyConfiguration(new DivisionEntityConfiguration());
                builder.ApplyConfiguration(new FinancialInstrumentEntityConfiguration());
                builder.ApplyConfiguration(new AdministratorEntityConfiguration());
                builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
                builder.ApplyConfiguration(new CountryEntityConfiguration());
                builder.ApplyConfiguration(new TradeSystem.Data.Configurations.Seed.DataOfIndividualClientEntityConfiguration());
                builder.ApplyConfiguration(new TradeSystem.Data.Configurations.Seed.TownEntityConfiguration());
            }

            base.OnModelCreating(builder);
        }
    }
}
