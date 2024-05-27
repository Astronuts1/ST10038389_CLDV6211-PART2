using Microsoft.AspNetCore.Mvc;
using ST10038389_CLDV6211_PART2.Models;
using System.Diagnostics;

namespace ST10038389_CLDV6211_PART2.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        public readonly ILogger<HomeController> _logger = logger;


        public IActionResult Index() //Calling the Home Page Class
        {
            return View();
        }

        public IActionResult AboutUs() //Calling the About Us Page Class
        {
            return View();
        }
        public IActionResult MyWork() //Calling the MyWork Page Class
        {
            return View();
        }
        public IActionResult ContactUs() //Calling the ContactUs Page Class
        {
            return View();
        }
        public IActionResult Login() //Calling the Login interface Page Class
        {
            return View();
        }
        public IActionResult SignUp() //Calling the SignUp Page Class
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
//-------------------------------------- END OF LINE --------------------------------------------------
