using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AionCodeMVC.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IGetIngredientService _getIngredientService;
        private readonly ICreateIngredientService _createIngredientService;
        private readonly IDeleteIngredientService _deleteIngredientService;
        private readonly IEditIngredientService _editIngredientService;
        private readonly IUploadIngredientPhotoService _uploadIngredientPhotoService;

        public IngredientController(IGetIngredientService getIngredientService, ICreateIngredientService createIngredientService, IDeleteIngredientService deleteIngredientService, IEditIngredientService editIngredientService, IUploadIngredientPhotoService uploadIngredientPhotoService)
        {
            _getIngredientService = getIngredientService;
            _createIngredientService = createIngredientService;
            _deleteIngredientService = deleteIngredientService;
            _editIngredientService = editIngredientService;
            _uploadIngredientPhotoService = uploadIngredientPhotoService;
        }

        // GET: IngredientController
        public async Task<ActionResult> Index(string searchString, string type)
        {
            if (!type.IsNullOrEmpty())
            {
                ViewBag.Type = type;
                IEnumerable<IngredientDTO>? modelType = await _getIngredientService.GetIngredientDTOListType(type);
                return View(modelType);
            }

            if (!searchString.IsNullOrEmpty())
            {
                ViewData["IngredientFilter"] = searchString;
                IEnumerable<IngredientDTO>? modelSearch = await _getIngredientService.GetIngredientDTOListContainString(searchString);
                return View(modelSearch);
            }
            IEnumerable<IngredientDTO>? model = await _getIngredientService.GetIngredientDTOListAll();
            return View(model);
        }

        // GET: IngredientController/Details/5
        public async Task<ActionResult> Details(int id, string type)
        {
            ViewBag.Type = type;
            var model = await _getIngredientService.GetByIdIngredientDetailedDTO(id);
            return View(model);
        }

        // GET: IngredientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngredientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IngredientDetailedDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                await _createIngredientService.CreateIngredient(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IngredientController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _getIngredientService.GetByIdIngredientEditedDTO(id);
            return View(model);
        }

        // POST: IngredientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IngredientEditDTO model)
        {
            try
            {
                await _editIngredientService.Edit(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await _getIngredientService.GetByIdIngredientDetailedDTO(id);
            return View(model);
        }

        // POST: Movies/Delete/name
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _deleteIngredientService.DeleteIngredient(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Upload(IFormFile file, int id)
        {
            try
            {
                await _uploadIngredientPhotoService.AddPhoto(file, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
