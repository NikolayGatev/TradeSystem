using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TradeSystem.Data.Models;

namespace TradeSystem.Web.Data
{
    public class TradeSystemDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public TradeSystemDbContext(DbContextOptions<TradeSystemDbContext> options)
            : base(options)
        {
        }
    }
}
