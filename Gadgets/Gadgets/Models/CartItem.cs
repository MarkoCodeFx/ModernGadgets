using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAutomationStore.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public bool UsePoints { get; set; }
        public int PointsToUse { get; set; }
        
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
} 