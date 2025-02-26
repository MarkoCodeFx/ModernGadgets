using HomeAutomationStore.Models;

namespace HomeAutomationStore.ViewModels
{
    public class MembershipViewModel
    {
        public User CurrentUser { get; set; }
        public List<MembershipPlanViewModel> MembershipPlans { get; set; }
    }

    public class MembershipPlanViewModel
    {
        public MembershipTier Tier { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; } // in days
        public string[] Benefits { get; set; }
    }
} 