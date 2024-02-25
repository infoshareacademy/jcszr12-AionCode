using Microsoft.AspNetCore.Mvc;

namespace AionCodeMVC.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
