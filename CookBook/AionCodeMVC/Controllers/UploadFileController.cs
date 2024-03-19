using CookBook.BuisnesLogic.Interfaces.RecipeInterfaces;
using CookBook.BuisnesLogic.Services.BlobServices;
using Microsoft.AspNetCore.Mvc;

namespace AionCodeMVC.Controllers
{
    public class UploadFileController : Controller
    {
        private readonly IBlobClientService _blobClientService;

        public UploadFileController(IBlobClientService blobClientService)
        {
            _blobClientService = blobClientService;
        }

        public IActionResult Index() 
        {
            return View();
        }
        [HttpPost] 
        public IActionResult Upload(IFormFile file)
        {
            var urlToSource = _blobClientService.AddPhoto(file);
            return RedirectToAction(nameof(Index));            
        }
    }
}
