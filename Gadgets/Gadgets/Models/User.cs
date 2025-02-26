using System;
using System.ComponentModel.DataAnnotations;

namespace HomeAutomationStore.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public int Points { get; set; }
        public virtual Membership Membership { get; set; }
        public bool HasActiveMembership => Membership != null && 
                                         Membership.IsActive && 
                                         Membership.EndDate > DateTime.UtcNow;

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
} 