using CookBook.BuisnesLogic.DTO;
using Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AionCodeMVC.Controllers
{
    public class MyFridgeController : Controller
    {
        // GET: MyFridge
        public IActionResult Index()
        {
            // Przykładowa lista obiektów MyFridgeDTO z wypełnionymi składnikami i ich szczegółami
            var myFridgeList = new List<MyFridgeDTO>
            {
                new MyFridgeDTO
                {
                    Id = 1,
                    Name = "Fridge 2",
                    UserCookBookId = "User2",
                    MyFridgeIngredients = new List<MyFridgeIngredientDTO>
                    {
                        new MyFridgeIngredientDTO
                        {
                            Id = 3,
                            IngredientDetails = new IngredientDetails { Id = 3, Name = "Butter", Description = "Organic Butter" },
                            AddDate = DateTime.Now,
                            Weight = 1.0m
                        },
                        new MyFridgeIngredientDTO
                        {
                            Id = 4,
                            IngredientDetails = new IngredientDetails { Id = 4, Name = "Cheese", Description = "Cheddar Cheese" },
                            AddDate = DateTime.Now,
                            Weight = 0.5m
                        }
                    }
                }
            };

            return View(myFridgeList);
        }


        // GET: MyFridge/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyFridge/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyFridge/Create
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

        // GET: MyFridge/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyFridge/Edit/5
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

        // GET: MyFridge/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyFridge/Delete/5
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
