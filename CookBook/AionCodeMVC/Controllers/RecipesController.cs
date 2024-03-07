using Microsoft.AspNetCore.Mvc;

namespace AionCodeMVC.Controllers
{
    public class RecipesController : Controller
    {
        public IActionResult Index()
        {
            //TempData["Active"] = 2;
            ViewBag.quantity = 2;

            return View();
        }
      
    }
}
