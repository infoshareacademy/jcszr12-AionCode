using CookBook.BuisnesLogic.Interfaces.RecipeInterfaces;
using CookBook.BuisnesLogic.Models;
using CookBook.BuisnesLogic.Services.RecipeServices;
using Microsoft.AspNetCore.Mvc;

namespace AionCodeMVC.Controllers
{
    public class RecipesController : Controller
    {
        private RecipeService _recipe;
        
        public RecipesController()
        {
            _recipe = new RecipeService();
            
        }
        public IActionResult Index()
        {
            ViewBag.quantity = 2;
            var model = _recipe.GetAll();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = _recipe.GetById(id);
            return View(model);
        }
       
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, Recipe model, IFormFile file)
        {
            try
            {
                _recipe.CreateRecipe(id, model, file);
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var model = _recipe.GetById(id);
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Recipe model)
        {
            try
            {
                
                _recipe.UpdateRecipe(id, model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            var model = _recipe.GetById(id);
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Recipe recipe)
        {
            try
            {
                _recipe.DeleteRecipe(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




    }
}
