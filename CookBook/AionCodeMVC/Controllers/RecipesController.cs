using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.RecipeInterfacces;
using Microsoft.AspNetCore.Mvc;

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

    }
}
