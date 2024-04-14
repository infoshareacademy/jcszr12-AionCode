using AionCodeMVC.Models;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Models;
using CookBook.BuisnesLogic.Services.IngredientServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

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
            IEnumerable<IngredientDTO>? model = await _getIngredientService.GetIngredientDTOListAll();
            return View(model);
        }

        // GET: IngredientController/Details/5
        public async Task<ActionResult> Details(string name)
        {
            var model = await _getIngredientService.GetByNameIngredientDetailedDTO(name);
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
        public async Task<ActionResult> Create(IngredientDetailedDTO model)
        {
            //throw new NotImplementedException();
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                await _createIngredientService.CreateIngredient(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IngredientController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            //return RedirectToAction(nameof(Index));
            var model = await _getIngredientService.GetByIdIngredientEditedDTO(id);
            return View(model); 
        }

        // POST: IngredientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IngredientEditDTO model)
        {
            //return RedirectToAction(nameof(Index));
            try
            {
                //_editIngredientService.Edit(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IngredientController/Delete/name
        public async Task<IActionResult> Delete(string? name)
        {
            IngredientDetailedDTO? model = await _getIngredientService.GetByNameIngredientDetailedDTO(name);
            return View(model);
        }

        // POST: Movies/Delete/name
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string name)
        {
            try
            {
                await _deleteIngredientService.DeleteIngredient(name);  
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Upload()
        {
            return RedirectToAction(nameof(Index));
            return View();
        }

        [HttpPost]
        public ActionResult Upload(IFormFile file, int id)
        {
            return RedirectToAction(nameof(Index));
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
