using CookBook.BuisnesLogic.Services;
using CookBook.BuisnesLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AionCodeMVC.Controllers
{
    public class RecipeController : Controller
    {
        private  RecipeService _recipe;
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
            var model = _recipe.GetById(id);
            return View(model);
        }

        // GET: RecipeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecipeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Recipe model)
        {
            _recipe.Create(model);
            TempData["Success added"] = "Produkt został dodany";
            return RedirectToAction(nameof(Index));
        }

        // GET: RecipeController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _recipe.GetById(id);

            return View(model);

        }

        // POST: RecipeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Recipe recipe)
        {
            try
            {
                _recipe.Update(id, recipe);
                TempData["Success edit"] = "Pomyślnie zmieniono dane";
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
        public ActionResult Delete(int id, Recipe model)
        {
            try
            {
                _recipe.DeleteById(id);
                TempData["Success delete"] = "Produkt został usunięty";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
