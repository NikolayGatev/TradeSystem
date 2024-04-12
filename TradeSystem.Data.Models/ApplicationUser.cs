using Microsoft.AspNetCore.Identity;
using TradeSystem.Data.Common.Base;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This is custom user class that works with the default ASP.NET Cpre Identity.
    /// You can add additional info to the built-in users.
    /// </summary>
    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public DateTime CreatedOn { get ; set ; }

        public DateTime? ModifiedOn { get ; set ; }

        public bool IsDeleted { get ; set ; }

        public DateTime? DeletedOn { get ; set ; }
    }
}
