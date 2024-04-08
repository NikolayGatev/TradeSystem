using Microsoft.AspNetCore.Identity;
using TradeSystem.Data.Common.Base;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This is custom user class that works with the default ASP.NET Cpre Identity.
    /// You can add additional info to the built-in users.
    /// </summary>
    public class ApplicationUser : IdentityUser<Guid>, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser() 
        {
            this.Administrators = new HashSet<Employee>();
            this.IndividualClients = new HashSet<DataOfIndividualClient>();
            this.CorporativeClients = new HashSet<DataOfCorporateveClient>();
        }

        public DateTime CreatedOn { get ; set ; }

        public DateTime? ModifiedOn { get ; set ; }

        public bool IsDeleted { get ; set ; }

        public DateTime? DeletedOn { get ; set ; }

        public virtual ICollection<Employee> Administrators { get; set; } = null!;

        public virtual ICollection<DataOfCorporateveClient> CorporativeClients { get; set; } = null!;

        public virtual ICollection<DataOfIndividualClient> IndividualClients { get; set; } = null!;
    }
}
