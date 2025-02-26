using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using HomeAutomationStore.Data;
using HomeAutomationStore.Models;
using HomeAutomationStore.ViewModels;

namespace HomeAutomationStore.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReviewViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Invalid review data" });
            }

            var userId = HttpContext.Session.GetInt32("UserId");
            var userName = HttpContext.Session.GetString("UserName");

            if (!userId.HasValue)
            {
                return Json(new { success = false, message = "Please log in to write a review" });
            }

            try
            {
                // Check if user has already reviewed this specific product
                var existingReview = await _context.Reviews
                    .AsNoTracking()
                    .FirstOrDefaultAsync(r => 
                        r.ProductId == model.ProductId && 
                        r.UserId == userId.Value);

                if (existingReview != null)
                {
                    return Json(new { success = false, message = "You have already reviewed this product" });
                }

                // Check if user has purchased this specific product
                var hasPurchased = await _context.OrderItems
                    .AsNoTracking()
                    .AnyAsync(oi => 
                        oi.ProductId == model.ProductId && 
                        oi.Order.UserId == userId.Value);

                if (!hasPurchased)
                {
                    return Json(new { success = false, message = "You can only review products you have purchased" });
                }

                var review = new Review
                {
                    ProductId = model.ProductId,
                    UserId = userId.Value,
                    Rating = model.Rating,
                    Comment = model.Comment,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();

                return Json(new { 
                    success = true, 
                    message = "Review added successfully",
                    review = new {
                        userName = userName,
                        rating = review.Rating,
                        comment = review.Comment,
                        createdAt = review.CreatedAt.ToString("MMM dd, yyyy")
                    }
                });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Failed to add review" });
            }
        }
    }
} 