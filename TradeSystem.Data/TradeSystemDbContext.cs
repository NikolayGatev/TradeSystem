using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TradeSystem.Data.Configurations;
using TradeSystem.Data.Models;

namespace TradeSystem.Web.Data
{
    public class TradeSystemDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        private readonly bool seedDb;

        public TradeSystemDbContext(DbContextOptions<TradeSystemDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
        }

        public DbSet<Address> Addresses { get; set; } = null!;

        public DbSet<Adminstrator> Adminstrators { get; set; } = null!;

        public DbSet<Client> Clients { get; set; } = null!;

        public DbSet<Country> Countries { get; set; } = null!;

        public DbSet<DataOfCorporateClient> DataOfCorporateClients { get; set; } = null!;

        public DbSet<DataOfIndividualClient> DataOfIndividualClients { get; set; } = null!;

        public DbSet<DepositedMoney> DepositedMoney { get; set; } = null!;

        public DbSet<Division> Divisions { get; set; } = null!;

        public DbSet<FinancialInstrument> FinancialInstruments { get; set; } = null!;

        public DbSet<IdentityDocument> IdentityDocuments { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<Town> Towns { get; set; } = null!;

        public DbSet<Trade> Trades { get; set; } = null!;

        public DbSet<TradeOrder> TradeOrders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DivisionEntityConfiguration());
            builder.ApplyConfiguration(new FinancialInstrumentEntityConfiguration());

            if(this.seedDb)
            {
                builder.ApplyConfiguration(new DivisionEntityConfiguration());
                builder.ApplyConfiguration(new FinancialInstrumentEntityConfiguration());
            }

            base.OnModelCreating(builder);
        }
    }
}
