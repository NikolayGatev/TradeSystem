using Microsoft.AspNetCore.Identity;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This is custom user class that works with the default ASP.NET Cpre Identity.
    /// You can add additional info to the built-in users.
    /// </summary>
    public class ApplicationUser : IdentityUser<Guid>
    {
    }
}
