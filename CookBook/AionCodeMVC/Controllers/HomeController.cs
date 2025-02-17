using AionCodeMVC.Models;
using Database;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AionCodeMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;

        public HomeController(ILogger<HomeController> logger, DatabaseContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        public IActionResult Index()
        {
            var result = _context.RecipeDetails.Where(x => x.Id == 10).FirstOrDefault();
            ViewBag.UserName = User.Identity.Name;

            return View(result);
        }

        public IActionResult Privacy()
        {
            ViewBag.UserName = User.Identity.Name;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Contact()
        {
            ViewBag.UserName = User.Identity.Name;
            return View();
        }
    }
}
