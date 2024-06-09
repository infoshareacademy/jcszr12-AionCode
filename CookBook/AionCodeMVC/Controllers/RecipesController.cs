using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.RecipeInterfacces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace AionCodeMVC.Controllers
{
    public class RecipesController : Controller
    {
        private IGetRecipeService _getRecipeService;
        private ICreateRecipeService _creaRecipeService;
        private IDeleteRecipeService _deleteRecipeService;
        private IEditRecipeService _editRecipeService;
        private IUploadRecipePhotoService _uploadRecipePhotoService;

        public RecipesController(IGetRecipeService getRecipeService, ICreateRecipeService createRecipeService, IDeleteRecipeService deleteRecipeService, IEditRecipeService editRecipeService,
            IUploadRecipePhotoService uploadRecipePhotoService)
        {
            _getRecipeService = getRecipeService;
            _creaRecipeService = createRecipeService;
            _deleteRecipeService = deleteRecipeService;
            _editRecipeService = editRecipeService;
            _uploadRecipePhotoService = uploadRecipePhotoService;
        }

        public async Task<ActionResult> Index(string serch, string type)
        {
            if (type != null)
            {
                IEnumerable<RecipeDTO>? modelType = await _getRecipeService.GetAllRecipeDTO();
                return View(modelType);
            }

            IEnumerable<RecipeDTO>? model = await _getRecipeService.GetAllRecipeDTO();
            return View(model);
        }
        public async Task<ActionResult> Details(int id)
        {
            var model = await _getRecipeService.GetRecipeByDetails(id);
            return View(model);
        }
        [Authorize(Policy = "StdUser")]
        public async Task<ActionResult> Create()
        {
            return View();
        }
        [Authorize(Policy = "StdUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RecipeDetailsDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                await _creaRecipeService.CreateRecipe(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Policy = "StdUser")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _getRecipeService.GetRecipeByDetails(id);
            return View(model);
        }

        // POST: Movies/Delete/name
        [Authorize(Policy = "StdUser")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _deleteRecipeService.DeleteRecipe(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
