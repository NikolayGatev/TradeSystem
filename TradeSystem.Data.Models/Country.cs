using System.ComponentModel.DataAnnotations;
using static TradeSystem.Common.EntityValidationConstants.CountryAndTownConstants;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class is for the countries the clients may be from.
    /// </summary>
    public class Country
    {
        public Country()
        {
            this.Towns = new HashSet<Town>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthName)]

        public string Name { get; set; } = string.Empty;

        public ICollection<Town> Towns { get; set; } = null!;
    }
}