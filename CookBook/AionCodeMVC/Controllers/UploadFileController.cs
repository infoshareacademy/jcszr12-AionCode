using Microsoft.AspNetCore.Mvc;

namespace AionCodeMVC.Controllers
{
    public class UploadFileController : Controller
    {
        public UploadFileController()
        {
        }
        public IActionResult Index() 
        {
            return View();
        }
        [HttpPost] 
        public IActionResult Upload(IFormFile file)
        {
            return RedirectToAction(nameof(Index));            
        }
    }
}
