using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.RecipeInterfacces;
using Microsoft.AspNetCore.Authorization;
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
        private IAddRecipeCommentService _addRecipeCommentService;

        public RecipesController(IGetRecipeService getRecipeService, ICreateRecipeService createRecipeService, IDeleteRecipeService deleteRecipeService, IEditRecipeService editRecipeService,
            IUploadRecipePhotoService uploadRecipePhotoService, IAddRecipeCommentService addRecipeCommentService)
        {
            _getRecipeService = getRecipeService;
            _creaRecipeService = createRecipeService;
            _deleteRecipeService = deleteRecipeService;
            _editRecipeService = editRecipeService;
            _uploadRecipePhotoService = uploadRecipePhotoService;
            _addRecipeCommentService = addRecipeCommentService;
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















































        // POST: IngredientController/AddComment
        [Authorize(Policy = "StdUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddComment(int recipeId, string text)
        {
            try
            {
                var userName = User.Identity.Name;

                var commentDTO = new RecipeCommentDTO
                {
                    Author = userName,
                    Text = text,
                    Date = DateTime.Now,
                    RecipeDetailsId = recipeId
                };

                await _addRecipeCommentService.AddComment(commentDTO);

                return RedirectToAction(nameof(Details), new { id = recipeId });
            }
            catch
            {
                return RedirectToAction(nameof(Details), new { id = recipeId, error = "Failed to add comment" });
            }
        }






    }
}
