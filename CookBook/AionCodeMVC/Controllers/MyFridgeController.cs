using AionCodeMVC.Models;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AionCodeMVC.Controllers
{
    public class MyFridgeController : Controller
    {
        private readonly IGetMyFridgeService _getMyFridgeService;
        private readonly ICreateFridgeService _createFridgeService;
        private readonly IDeleteMyFridgeService _deleteMyFridgeIngredientService;
        private readonly IGetIngredientService _getIngredientService;
        private readonly IAddFridgeIngredientService _addFridgeIngredientService;

        public MyFridgeController(IGetMyFridgeService getMyFridgeService, ICreateFridgeService createFridgeService, IDeleteMyFridgeService deleteMyFridgeIngredientService, IGetIngredientService getIngredientService, IAddFridgeIngredientService addFridgeIngredientService)
        {
            _getMyFridgeService = getMyFridgeService;
            _createFridgeService = createFridgeService;
            _deleteMyFridgeIngredientService = deleteMyFridgeIngredientService;
            _getIngredientService = getIngredientService;
            _addFridgeIngredientService = addFridgeIngredientService;
        }

        // GET: MyFridge
        [Authorize(Policy = "StdUser")]
        public async Task<IActionResult> Index()
        {
            var myFridges = await _getMyFridgeService.GetAllMyFridges();
            var myProposedRecipes = await _getMyFridgeService.GetProposedRecipes(myFridges);

            var model = new MyFridgeViewModel
            {
                MyFridges = myFridges,
                MyProposedRecipes = myProposedRecipes
            };

            return View(model);
            //return View(myFridges);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                try
                {
                    // Wywołanie serwisu do dodawania lodówki
                    await _createFridgeService.AddFridge(new MyFridgeDTO { Name = name });
                    return RedirectToAction(nameof(Index)); // Przekierowanie do akcji Index
                }
                catch (Exception ex)
                {
                    // Obsługa błędów - można zalogować błąd lub wyświetlić odpowiedni komunikat użytkownikowi
                    ModelState.AddModelError("", "Wystąpił błąd podczas dodawania lodówki.");
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                ModelState.AddModelError("name", "Nazwa lodówki jest wymagana.");
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: MyFridge/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(MyFridgeIngredientDTO myFridgeIngredientDTO)
        {
            try
            {
                await _deleteMyFridgeIngredientService.DeleteFridgeIngredient(myFridgeIngredientDTO);

                // Przekieruj użytkownika po pomyślnym usunięciu
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { message = ex.Message });
            }
        }

        public async Task<JsonResult> SearchIngredients(string term)
        {
            var searchedIngredients = await _getIngredientService.GetIngredientsByTerm(term);
            return Json(searchedIngredients);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddIngredient(MyFridgeIngredientDTO myFridgeIngredientDTO, string ingredientName)
        {
            if (myFridgeIngredientDTO != null)
            {
                await _addFridgeIngredientService.AddFridgeIngredient(myFridgeIngredientDTO, ingredientName);
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: MyFridge/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFridge(int id)
        {
            try
            {
                await _deleteMyFridgeIngredientService.DeleteFridge(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot delete fridge.");
            }
        }
    }
}
