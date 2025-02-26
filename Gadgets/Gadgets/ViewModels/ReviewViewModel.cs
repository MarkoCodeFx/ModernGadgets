using System.ComponentModel.DataAnnotations;

namespace HomeAutomationStore.ViewModels
{
    public class ReviewViewModel
    {
        public int ProductId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [StringLength(1000)]
        public string Comment { get; set; }
    }
} 