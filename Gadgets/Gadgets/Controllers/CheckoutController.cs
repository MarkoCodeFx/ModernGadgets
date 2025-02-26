using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using HomeAutomationStore.Data;
using HomeAutomationStore.Models;
using Microsoft.AspNetCore.Authorization;

namespace HomeAutomationStore.Controllers
{
    [Authorize]
    public class CheckoutController : BaseController
    {
        public CheckoutController(ApplicationDbContext context)
            : base(context)
        {
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            try
            {
                using var transaction = await _context.Database.BeginTransactionAsync();

                var user = await _context.Users
                    .Include(u => u.Membership)
                    .FirstOrDefaultAsync(u => u.Id == userId.Value);

                var cartItems = await _context.CartItems
                    .Include(c => c.Product)
                    .Where(c => c.UserId == userId.Value)
                    .ToListAsync();

                if (!cartItems.Any())
                {
                    return RedirectToAction("Index", "Cart");
                }

                var order = new Order
                {
                    UserId = userId.Value,
                    OrderDate = DateTime.UtcNow,
                    OrderStatus = "Pending",
                    ShippingAddress = "Default Shipping Address"
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                decimal totalAmount = 0;
                int earnedPoints = 0;

                foreach (var cartItem in cartItems)
                {
                    decimal itemPrice = cartItem.Product.Price;
                    decimal originalPrice = cartItem.Product.Price;
                    decimal discountPercentage = 0;

                    if (user.HasActiveMembership)
                    {
                        discountPercentage = 0.1M;
                        itemPrice = itemPrice * 0.9M;
                    }

                    var orderItem = new OrderItem
                    {
                        OrderId = order.Id,
                        ProductId = cartItem.ProductId,
                        Quantity = cartItem.Quantity,
                        Price = itemPrice,
                        OriginalPrice = originalPrice,
                        DiscountPercentage = discountPercentage
                    };

                    _context.OrderItems.Add(orderItem);
                    totalAmount += itemPrice * cartItem.Quantity;
                    earnedPoints += cartItem.Product.PurchasePoints * cartItem.Quantity;
                }

                order.TotalAmount = totalAmount;
                user.Points += earnedPoints;

                _context.CartItems.RemoveRange(cartItems);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                HttpContext.Session.SetInt32("UserPoints", user.Points);
                TempData["SuccessMessage"] = $"Order placed successfully! You earned {earnedPoints} points!";

                return RedirectToAction("Index", "Orders");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "An error occurred while processing your order.";
                return RedirectToAction("Index", "Cart");
            }
        }
    }
} 