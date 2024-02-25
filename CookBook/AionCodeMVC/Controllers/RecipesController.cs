using Microsoft.AspNetCore.Mvc;

namespace AionCodeMVC.Controllers
{
    public class RecipesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
