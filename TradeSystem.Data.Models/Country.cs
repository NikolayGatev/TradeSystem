using System.ComponentModel.DataAnnotations;

namespace TradeSystem.Data.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]

        public string Name { get; set; } = string.Empty;
    }
}