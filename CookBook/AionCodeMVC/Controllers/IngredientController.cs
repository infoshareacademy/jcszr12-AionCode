﻿using AionCodeMVC.Models;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Models;
using CookBook.BuisnesLogic.Services.IngredientServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AionCodeMVC.Controllers
{
    public class IngredientController : Controller
    {

        private IGetIngredientService _getIngredientService;
        private ICreateIngredientService _createIngredientService;
        private IDeleteIngredientService _deleteIngredientService;
        private IEditIngredientService _editIngredientService;
        private IUploadIngredientPhotoService _uploadIngredientPhotoService;

        public IngredientController(IGetIngredientService getIngredientService, ICreateIngredientService createIngredientService, IDeleteIngredientService deleteIngredientService, IEditIngredientService editIngredientService, IUploadIngredientPhotoService uploadIngredientPhotoService)
        {
            _getIngredientService = getIngredientService;
            _createIngredientService= createIngredientService;
            _deleteIngredientService = deleteIngredientService;
            _editIngredientService = editIngredientService;
            _uploadIngredientPhotoService = uploadIngredientPhotoService;
        }


        // GET: IngredientController
        public async Task<ActionResult> Index()
        {
            IEnumerable<Ingredient>? model = await _getIngredientService.GetAll();
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


        // GET: IngredientController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _getIngredientService.GetByID(id);
            return View(model);
        }

        // POST: IngredientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Ingredient model)
        {
            try
            {
                _editIngredientService.Edit(model);
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
            var model = _getIngredientService.GetByID(id);
            return View(model);
        }

        // POST: IngredientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Ingredient ingredient)
        {
            try
            {
                _deleteIngredientService.DeleteIngredient(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(IFormFile file, int id)
        {
            try
            {
                var urlToSource = _uploadIngredientPhotoService.AddPhoto(file, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




    }
}
