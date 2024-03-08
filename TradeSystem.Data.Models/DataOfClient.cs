using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TradeSystem.Common.GeneralApplicationConstants;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This is abstract class, which contains the submitted information about each client,
    /// and is no different for corporate or individual client.
    /// </summary>
    public abstract class DataOfClient
    {
        [Key]

        public Guid Id { get; set; }

        public bool IsCreatedAcount { get; set; }

        public int NationalityId { get; set; }

        [Required]
        [ForeignKey(nameof(NationalityId))]

        public Country Nationality { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(AddressId))]

        public virtual Address Address { get; set; } = null!;

        public Guid AddressId { get; set; }

        [Required]
        [MaxLength(MaxLengthPhoneNumber)]

        public string PhoneNumber { get; set; } = null!;

        [ForeignKey(nameof(IdentityDocumentId))]

        public virtual IdentityDocument? IdentityDocument { get; set; } = null!;

        public Guid? IdentityDocumentId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? AuthorisedOn { get; set; }

        [ForeignKey(nameof(AdministratorId))]

        public virtual Administrator? Adminstrator { get; set; }

        public Guid? AdministratorId { get; set; }
    }
}
