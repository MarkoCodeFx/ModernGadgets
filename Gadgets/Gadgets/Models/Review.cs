using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAutomationStore.Models
{
    public class Review
    {
        public int Id { get; set; }
        
        public int ProductId { get; set; }
        public int UserId { get; set; }
        
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        
        [Required]
        [StringLength(1000)]
        public string Comment { get; set; }
        
        public DateTime CreatedAt { get; set; }
        
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
} 