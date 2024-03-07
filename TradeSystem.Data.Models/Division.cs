using System.ComponentModel.DataAnnotations;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class contains information about each Division in the organization.
    /// </summary>
    public class Division
    {
        public int Id { get; set; }

        [Required]

        public string Name { get; set; } = string.Empty;
    }
}