using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeAutomationStore.Models;
using Microsoft.EntityFrameworkCore;
using HomeAutomationStore.Data;

namespace HomeAutomationStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var popularProducts = await _context.Products
                .Include(p => p.Reviews)
                .OrderByDescending(p => p.Reviews.Count)
                .Take(4)
                .ToListAsync();

            return View(popularProducts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
