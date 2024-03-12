using AionCodeMVC.Interfaces;
using AionCodeMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AionCodeMVC.Controllers
{
    public class IngredientController : Controller
    {

        private IGetIngredientService _getIngredientService;
        private ICreateIngredientService _createIngredientService;
        public IngredientController(IGetIngredientService getIngredientService, ICreateIngredientService createIngredientService)
        {
            _getIngredientService = getIngredientService;
            _createIngredientService= createIngredientService;
        }


        // GET: IngredientController
        public ActionResult Index()
        {
            var model = _getIngredientService.GetAll();
            return View(model);
        }

        // GET: IngredientController/Details/5
        public ActionResult Details(int id)
        {
            var model = _getIngredientService.GetByID(id);
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
        public ActionResult Create(Ingredient model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                _createIngredientService.CreateIngredient(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /*
         *        // GET: IngredientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngredientController/Create
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
        }*/

        // GET: IngredientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IngredientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: IngredientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IngredientController/Delete/5
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
