using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class contains documents uploaded by a client 
    /// </summary>
    public class IdentityDocument
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ClientId { get; set; }

        [Required]
        [ForeignKey(nameof(ClientId))]

        public virtual Client Client { get; set; } = null!;

        [Required]

        public string Extension { get; set; } = string.Empty;

        [Required]

        public string RemoteImageUrl { get; set; } = string.Empty;
    }
}