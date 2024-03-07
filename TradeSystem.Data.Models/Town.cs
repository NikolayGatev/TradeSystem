using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TradeSystem.Common.EntityValidationConstants.CountryAndTownConstants;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class contains information clients` towns.
    /// </summary>
    public class Town
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxLengthName)]

        public string Name { get; set; } = string.Empty;

        public int CountryId { get; set; }

        [Required]
        [ForeignKey(nameof(CountryId))]

        public Country Country { get; set; } = null!;
    }
}