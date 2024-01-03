using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Linq;
using Zencareservice.Models;

namespace Zencareservice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

       

        public IActionResult CapturePhoto()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Index(string user)
        {
            user = "Hi ZencareUser!";

            if (!string.IsNullOrEmpty(user))
            {
                ViewBag.JavaScriptFunction = string.Format("ShowGreetings('{0}');", user);
            }
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var problemDetails = new ProblemDetails
            {
                Title = "An error occurred while processing your request.",
                Detail = exceptionDetails?.Error.Message,
                Status = 500 // Internal Server Error
                             // Add other properties as needed
            };
            return View("Error", problemDetails);
        }
    }
}