using System.ComponentModel.DataAnnotations;

namespace HomeAutomationStore.ViewModels
{
    public class CheckoutViewModel
    {
        [Required(ErrorMessage = "Shipping address is required")]
        public string ShippingAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Card holder name is required")]
        [Display(Name = "Card Holder Name")]
        public string CardHolderName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Card number is required")]
        [Display(Name = "Card Number")]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Please enter a valid 16-digit card number")]
        public string CardNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Expiry month is required")]
        [Display(Name = "Expiry Month")]
        [Range(1, 12, ErrorMessage = "Please enter a valid month (1-12)")]
        public int ExpiryMonth { get; set; }

        [Required(ErrorMessage = "Expiry year is required")]
        [Display(Name = "Expiry Year")]
        [Range(2024, 2034, ErrorMessage = "Please enter a valid year")]
        public int ExpiryYear { get; set; }

        [Required(ErrorMessage = "CVV is required")]
        [Display(Name = "CVV")]
        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Please enter a valid CVV")]
        public string CVV { get; set; } = string.Empty;

        public bool UsePoints { get; set; }
        public int PointsToUse { get; set; }
    }
} 