using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using HomeAutomationStore.Data;
using HomeAutomationStore.Models;
using HomeAutomationStore.ViewModels;

namespace HomeAutomationStore.Controllers
{
    public class MembershipController : BaseController
    {
        public MembershipController(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var user = await _context.Users
                .Include(u => u.Membership)
                .FirstOrDefaultAsync(u => u.Id == userId.Value);

            var membershipPlans = new List<MembershipPlanViewModel>
            {
                new MembershipPlanViewModel 
                { 
                    Tier = MembershipTier.Bronze,
                    Price = 9.99m,
                    Duration = 30,
                    Benefits = new[] { "Access to member-only products", "Earn points on purchases", "5% discount" }
                },
                new MembershipPlanViewModel 
                { 
                    Tier = MembershipTier.Silver,
                    Price = 19.99m,
                    Duration = 30,
                    Benefits = new[] { "All Bronze benefits", "Double points on purchases", "10% discount" }
                },
                new MembershipPlanViewModel 
                { 
                    Tier = MembershipTier.Gold,
                    Price = 29.99m,
                    Duration = 30,
                    Benefits = new[] { "All Silver benefits", "Triple points on purchases", "15% discount", "Free monthly product" }
                }
            };

            var viewModel = new MembershipViewModel
            {
                CurrentUser = user,
                MembershipPlans = membershipPlans
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Purchase(MembershipTier tier)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var user = await _context.Users
                .Include(u => u.Membership)
                .FirstOrDefaultAsync(u => u.Id == userId.Value);

            if (user == null)
            {
                return NotFound();
            }

            decimal price = tier switch
            {
                MembershipTier.Bronze => 9.99m,
                MembershipTier.Silver => 19.99m,
                MembershipTier.Gold => 29.99m,
                _ => 0m
            };

            var membership = new Membership
            {
                UserId = user.Id,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddMonths(1),
                IsActive = true,
                Tier = tier,
                Price = price
            };

            if (user.Membership != null)
            {
                _context.Memberships.Remove(user.Membership);
            }

            _context.Memberships.Add(membership);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Successfully purchased {tier} membership!";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> RedeemPoints(int productId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return Json(new { success = false, message = "Please log in" });
            }

            var user = await _context.Users.FindAsync(userId.Value);
            var product = await _context.Products.FindAsync(productId);

            if (user.Points < 1000)
            {
                return Json(new { success = false, message = "Not enough points" });
            }

            // Create free order
            var order = new Order
            {
                UserId = userId.Value,
                OrderDate = DateTime.UtcNow,
                TotalAmount = 0,
                OrderStatus = "Completed",
                ShippingAddress = "Same as user address" // You might want to prompt for this
            };

            _context.Orders.Add(order);
            
            // Deduct points
            user.Points -= 1000;
            
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Product redeemed successfully!" });
        }
    }
} 