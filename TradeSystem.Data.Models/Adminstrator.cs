using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static TradeSystem.Common.GeneralApplicationConstants;


namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class contains information about each employee.
    /// </summary>
    public class Adminstrator
    {
        [Key]

        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUserId))]

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        public Guid ApplicationUserId { get; set; }

        [Required]
        [MaxLength(MaxLengthIndividualName)]

        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxLengthIndividualName)]

        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(MaxLengthPhoneNumber)]

        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(DivisionId))]

        public Division Division { get; set; } = null!;

        public int DivisionId { get; set; }
    }
}
