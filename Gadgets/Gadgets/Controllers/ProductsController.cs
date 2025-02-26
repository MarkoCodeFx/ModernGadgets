using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HomeAutomationStore.Data;
using HomeAutomationStore.Models;

namespace HomeAutomationStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string category, string searchString, decimal? minPrice, decimal? maxPrice)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            var products = from p in _context.Products.Include(p => p.Reviews)
                          select p;

            // Apply category filter
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category);
            }

            // Apply search filter
            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString) 
                                          || p.Description.Contains(searchString));
            }

            // Apply price range filter
            if (minPrice.HasValue)
            {
                products = products.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                products = products.Where(p => p.Price <= maxPrice.Value);
            }

            // Order by name
            products = products.OrderBy(p => p.Name);

            if (userId.HasValue)
            {
                var user = await _context.Users
                    .Include(u => u.Membership)
                    .FirstOrDefaultAsync(u => u.Id == userId.Value);
                ViewBag.UserPoints = user?.Points ?? 0;
                ViewBag.HasActiveMembership = user?.HasActiveMembership ?? false;
                ViewBag.CurrentUser = user;
            }
            else
            {
                ViewBag.UserPoints = 0;
                ViewBag.HasActiveMembership = false;
            }

            ViewBag.UserId = userId;
            return View(await products.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            
            var product = await _context.Products
                .Include(p => p.Reviews)
                    .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            if (userId.HasValue)
            {
                var user = await _context.Users
                    .Include(u => u.Membership)
                    .FirstOrDefaultAsync(u => u.Id == userId.Value);
                ViewBag.CurrentUser = user;
            }

            ViewBag.UserId = userId;
            return View(product);
        }
    }
}