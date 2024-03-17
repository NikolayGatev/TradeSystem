using System.ComponentModel.DataAnnotations;
using TradeSystem.Data.Common.Base;
using static TradeSystem.Common.EntityValidationConstants.CountryAndTownConstants;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class is for the countries the clients may be from.
    /// </summary>
    public class Country : BaseDeletableModel
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
            this.CorporativeClients = new HashSet<DataOfCorporateveClient>();
            this.InvidualClients = new HashSet<DataOfIndividualClient>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthName)]

        public string Name { get; set; } = string.Empty;

        public ICollection<Town> Towns { get; set; } = null!;

        public ICollection<DataOfCorporateveClient> CorporativeClients { get; set; } = null!;

        public ICollection<DataOfIndividualClient> InvidualClients { get; set; } = null!;

    }
}