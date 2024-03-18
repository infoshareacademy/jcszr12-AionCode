using CookBook.BuisnesLogic.Interfaces.RecipeInterfaces;
using CookBook.BuisnesLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AionCodeMVC.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IGetRecipeService _getRecipeService;
        private readonly ICreateRecipeService _createRecipeService;
        private readonly IDeleteRecipeService _deleteRecipeService;
        private readonly IEditRecipeService _editRecipeService;

        public RecipesController(IGetRecipeService getRecipeService, ICreateRecipeService createRecipeService, IDeleteRecipeService deleteRecipeService, IEditRecipeService editRecipeService)
        {
            _getRecipeService = getRecipeService;
            _createRecipeService = createRecipeService;
            _deleteRecipeService = deleteRecipeService;
            _editRecipeService = editRecipeService;
        }

        public IActionResult Index()
        {
            ViewBag.quantity = 2;
            var model = _getRecipeService.GetAllRecipe();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = _getRecipeService.GetById(id);
            return View(model);
        }

       
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Recipe model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                _createRecipeService.CreateRecipe(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        
        public ActionResult Edit(int id)
        {
            var model = _getRecipeService.GetById(id);
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Recipe model)
        {
            try
            {
                _editRecipeService.EditRecipe(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            var model = _getRecipeService.GetById(id);
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Recipe ingredient)
        {
            try
            {
                _deleteRecipeService.DeleteRecipe(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




    }
}
