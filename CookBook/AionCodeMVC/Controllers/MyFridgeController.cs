using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces;
using Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AionCodeMVC.Controllers
{
    public class MyFridgeController : Controller
    {

        private readonly IGetMyFridgeService _getMyFridgeService;

        public MyFridgeController(IGetMyFridgeService getMyFridgeService)
        {
            _getMyFridgeService = getMyFridgeService;
        }


        // GET: MyFridge
        public async Task<IActionResult> Index()
        {
            var myFridges = await _getMyFridgeService.GetAllMyFridges();

            // Przekazanie lodówek do widoku
            return View(myFridges);
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
