﻿using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AionCodeMVC.Controllers
{
    public class MyFridgeController : Controller
    {
        private readonly IGetMyFridgeService _getMyFridgeService;
        private readonly ICreateFridgeService _createFridgeService;
        private readonly IDeleteMyFridgeIngredientService  _deleteMyFridgeIngredientService;
        private readonly IGetIngredientService _getIngredientService;
        private readonly IAddFridgeIngredientService _addFridgeIngredientService;

        public MyFridgeController(IGetMyFridgeService getMyFridgeService, ICreateFridgeService createFridgeService, IDeleteMyFridgeIngredientService deleteMyFridgeIngredientService, IGetIngredientService getIngredientService, IAddFridgeIngredientService addFridgeIngredientService)
        {
            _getMyFridgeService = getMyFridgeService;
            _createFridgeService = createFridgeService;
            _deleteMyFridgeIngredientService = deleteMyFridgeIngredientService;
            _getIngredientService = getIngredientService;
            _addFridgeIngredientService = addFridgeIngredientService;
        }

        // GET: MyFridge
        public async Task<IActionResult> Index()
        {
            var myFridges = await _getMyFridgeService.GetAllMyFridges();
            return View(myFridges);
        }

        // GET: MyFridge/Create
        // GET: /MyFridge/Create
        public IActionResult Create()
        {
            return View();
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
                // Obsłuż błędy (np. wyświetl stronę błędu lub zaloguj)
                // Tutaj przekierowujemy do akcji 'Error' z kontrolera domyślnego 'Home'
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
            if (myFridgeIngredientDTO!=null)
            {
                await _addFridgeIngredientService.AddFridgeIngredien(myFridgeIngredientDTO, ingredientName);
            }
            return RedirectToAction(nameof(Index));
        }




        // GET: MyFridge/Details/5
        public IActionResult Details(int id)
        {
            // Wyszukaj szczegóły lodówki na podstawie ID i wyświetl widok
            return View();
        }

        // GET: MyFridge/Edit/5
        public IActionResult Edit(int id)
        {
            // Wyszukaj lodówkę do edycji na podstawie ID i wyświetl formularz edycji
            return View();
        }

        // POST: MyFridge/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MyFridgeDTO fridgeDTO)
        {
            // Edytuj lodówkę na podstawie danych z formularza
            return RedirectToAction(nameof(Index));
        }



        // POST: MyFridge/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Usuń lodówkę na podstawie ID i przekieruj użytkownika do akcji Index
            return RedirectToAction(nameof(Index));
        }
    }
}
