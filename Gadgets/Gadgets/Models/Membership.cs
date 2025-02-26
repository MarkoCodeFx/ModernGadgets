using System;

namespace HomeAutomationStore.Models
{
    public class Membership
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public MembershipTier Tier { get; set; }
        public decimal Price { get; set; }

        public virtual User User { get; set; }
    }

    public enum MembershipTier
    {
        None,
        Bronze,
        Silver,
        Gold
    }
} 