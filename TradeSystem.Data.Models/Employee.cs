using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TradeSystem.Data.Common.Base;
using static TradeSystem.Common.GeneralApplicationConstants;


namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class contains information about each employee.
    /// </summary>
    public class Employee : BaseDeletableModel
    {
        public Employee()
        {
            this.CorporativeClients = new HashSet<DataOfCorporateveClient>();
            this.IndividualClients = new HashSet<DataOfIndividualClient>();
        }

        [Key]

        public Guid Id { get; set; }

        public bool IsApproved { get; set; }

        [Required]
        [ForeignKey(nameof(ApplicationUserId))]

        public virtual ApplicationUser ApplicationUser { get; set; } = null!;

        [Required]

        public string ApplicationUserId { get; set; } = null!;

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

        public virtual ICollection<DataOfCorporateveClient> CorporativeClients { get; set; } = null!;

        public virtual ICollection<DataOfIndividualClient> IndividualClients { get; set; } = null!;
    }
}
