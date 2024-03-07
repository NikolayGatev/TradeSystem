﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradeSystem.Data.Models
{
    /// <summary>
    /// This class is a many-to-many relationship between Order and 
    /// Trade and shows the volume for each execution.
    /// </summary>
    public class TradeOrder
    {
        [Key]

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid OrderId { get; set; }

        [Required]
        [ForeignKey(nameof(OrderId))]

        public Order Order { get; set; } = null!;

        public Guid TradeId { get; set; }

        [Required]
        [ForeignKey(nameof(TradeId))]

        public Trade Trade { get; set; } = null!;

        public uint Volume { get; set; }
    }
}