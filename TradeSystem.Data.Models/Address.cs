using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TradeSystem.Common.EntityValidationConstants.AddressConstants;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class contains information about exact address.
    /// </summary>
    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(CountryId))]

        public Country Country { get; set; } = null!;

        public int CountryId { get; set; }

        [Required]
        [StringLength(MaxLengthPostCode)]

        public string PostCode { get; set; } = string.Empty;

        [ForeignKey(nameof(TownId))]

        public Town Town { get; set; } = null!;

        public int TownId { get; set; }

        [MaxLength(MaxLengthDistrict)]

        public string? district { get; set; }

        public string? Street { get; set; }

        [Required]
        [StringLength(MaxLengthPostCode)]

        public string Number { get; set; } = string.Empty;

        public byte? Floor { get; set; }

        public byte? Flat { get; set; }
    }
}