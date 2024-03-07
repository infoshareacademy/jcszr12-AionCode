using CookBook.BuisnesLogic.Services;
using CookBook.BuisnesLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AionCodeMVC.Controllers
{
    public class RecipeController : Controller
    {
        private readonly RecipeService _recipe;
        // GET: RecipeController
        public RecipeController() 
        {
            _recipe = new RecipeService();
        }
        public ActionResult Index()
        {
            var model = _recipe.GetAll();
            return View(model);
        }

        // GET: RecipeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RecipeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipeController/Edit/5
        public ActionResult Edit(int id)
        {
            var recipeToEdit = _recipe.GetById(id);

            if (recipeToEdit != null)
            {
                return View(recipeToEdit);
            }
            else 
            {
                return RedirectToAction(nameof(Index));
            }
            
        }

        // POST: RecipeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                return View(recipe);
            }

            try
            {
                _recipe.Update(id, recipe);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecipeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
