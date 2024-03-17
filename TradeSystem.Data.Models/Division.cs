using System.ComponentModel.DataAnnotations;
using TradeSystem.Data.Common.Base;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class contains information about each Division in the organization.
    /// </summary>
    public class Division : BaseModel
    {
        [Key]

        public int Id { get; set; }

        [Required]

        public string Name { get; set; } = string.Empty;
    }
}