using Microsoft.AspNetCore.Identity;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This is custom user class that works with the default ASP.NET Cpre Identity.
    /// You can add additional info to the built-in users.
    /// </summary>
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Administrators = new HashSet<Administrator>();
            this.IndividualClients = new HashSet<DataOfIndividualClient>();
            this.CorporativeClients = new HashSet<DataOfCorporateveClient>();
        }

        ICollection<Administrator> Administrators { get; set; } = null!;

        public virtual ICollection<DataOfCorporateveClient> CorporativeClients { get; set; } = null!;

        public virtual ICollection<DataOfIndividualClient> IndividualClients { get; set; } = null!;
    }
}
