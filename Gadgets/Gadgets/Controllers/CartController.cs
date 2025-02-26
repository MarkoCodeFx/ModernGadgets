using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using HomeAutomationStore.Data;
using HomeAutomationStore.Models;
using Microsoft.AspNetCore.Authorization;

namespace HomeAutomationStore.Controllers
{
    [Authorize]
    public class CartController : BaseController
    {
        public CartController(ApplicationDbContext context)
            : base(context)
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
            ViewBag.CurrentUser = user;

            var cartItems = await _context.CartItems
                .Include(ci => ci.Product)
                .Where(ci => ci.UserId == userId.Value)
                .ToListAsync();

            return View(cartItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return Json(new { success = false, message = "Please log in to add items to cart" });
            }

            try
            {
                // Get the product and check if it's member-only
                var product = await _context.Products.FindAsync(productId);
                if (product == null)
                {
                    return Json(new { success = false, message = "Product not found" });
                }

                // Check if product is member-only and user has active membership
                if (product.IsMemberOnly)
                {
                    var user = await _context.Users
                        .Include(u => u.Membership)
                        .FirstOrDefaultAsync(u => u.Id == userId.Value);

                    if (!user.HasActiveMembership)
                    {
                        return Json(new { success = false, message = "This product is for members only. Please upgrade to a membership to purchase." });
                    }
                }

                var cartItem = await _context.CartItems
                    .FirstOrDefaultAsync(ci => ci.ProductId == productId && ci.UserId == userId.Value);

                if (cartItem == null)
                {
                    cartItem = new CartItem
                    {
                        ProductId = productId,
                        UserId = userId.Value,
                        Quantity = quantity
                    };
                    _context.CartItems.Add(cartItem);
                }
                else
                {
                    cartItem.Quantity += quantity;
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Product added to cart" });
            }
            catch (Exception)
            {
                return Json(new { success = false, message = "Failed to add product to cart" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                return RedirectToAction("Login", "Account");
            }

            var cartItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.ProductId == productId && ci.UserId == userId.Value);

            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
} 