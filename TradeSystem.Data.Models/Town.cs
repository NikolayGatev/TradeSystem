using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TradeSystem.Data.Common.Base;
using static TradeSystem.Common.EntityValidationConstants.CountryAndTownConstants;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class contains information clients` towns.
    /// </summary>
    public class Town : BaseDeletableModel
    {
        public Town()
        {
            this.CorporativeClients = new HashSet<DataOfCorporateveClient>();
            this.InvidualClients = new HashSet<DataOfIndividualClient>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthName)]

        public string Name { get; set; } = string.Empty;

        public int CountryId { get; set; }

        [Required]
        [ForeignKey(nameof(CountryId))]

        public Country Country { get; set; } = null!;

        public ICollection<DataOfCorporateveClient> CorporativeClients { get; set; } = null!;

        public ICollection<DataOfIndividualClient> InvidualClients { get; set; } = null!;
    }
}