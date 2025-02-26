using Microsoft.AspNetCore.Mvc;
using HomeAutomationStore.Data;

namespace HomeAutomationStore.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _context;

        public BaseController(ApplicationDbContext context)
        {
            _context = context;
        }
    }
} 