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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}