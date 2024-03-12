using Microsoft.AspNetCore.Mvc;

namespace AionCodeMVC.Controllers
{
    public class RecipesController : Controller
    {
        public IActionResult Index()
        {
            
            ViewBag.quantity = 2;
            return View();
        }
      
    }
}
