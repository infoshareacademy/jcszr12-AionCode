using Microsoft.AspNetCore.Mvc;

namespace AionCodeMVC.Controllers
{
    public class ShowRecipeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
