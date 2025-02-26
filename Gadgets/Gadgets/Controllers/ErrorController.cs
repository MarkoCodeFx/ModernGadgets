using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace HomeAutomationStore.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found";
                    ViewBag.ErrorTitle = "Page Not Found";
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Sorry, something went wrong on the server";
                    ViewBag.ErrorTitle = "Server Error";
                    break;
                default:
                    ViewBag.ErrorMessage = "Sorry, something went wrong";
                    ViewBag.ErrorTitle = "Error";
                    break;
            }

            return View("Error");
        }

        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            
            ViewBag.ErrorTitle = "Error";
            ViewBag.ErrorMessage = "An error occurred while processing your request.";
            
            return View();
        }
    }
} 