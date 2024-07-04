using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AionCodeMVC.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IGetIngredientService _getIngredientService;
        private readonly ICreateIngredientService _createIngredientService;
        private readonly IDeleteIngredientService _deleteIngredientService;
        private readonly IEditIngredientService _editIngredientService;
        private readonly IUploadIngredientPhotoService _uploadIngredientPhotoService;
        private readonly IAddCommentService _addCommentService;
        private readonly IDeleteCommentService _deleteCommentService;

        public IngredientController(IGetIngredientService getIngredientService, ICreateIngredientService createIngredientService, IDeleteIngredientService deleteIngredientService, IEditIngredientService editIngredientService, IUploadIngredientPhotoService uploadIngredientPhotoService, IAddCommentService addCommentService, IDeleteCommentService deleteCommentService)
        {
            _getIngredientService = getIngredientService;
            _createIngredientService = createIngredientService;
            _deleteIngredientService = deleteIngredientService;
            _editIngredientService = editIngredientService;
            _uploadIngredientPhotoService = uploadIngredientPhotoService;
            _addCommentService = addCommentService;
            _deleteCommentService = deleteCommentService;
        }

        // GET: IngredientController
        public async Task<ActionResult> Index(string searchString, string type)
        {
            if (!type.IsNullOrEmpty())
            {
                ViewBag.Type = type;
                IEnumerable<IngredientDTO>? modelType = await _getIngredientService.GetIngredientDTOListType(type);
                return View(modelType);
            }

            if (!searchString.IsNullOrEmpty())
            {
                ViewData["IngredientFilter"] = searchString;
                IEnumerable<IngredientDTO>? modelSearch = await _getIngredientService.GetIngredientDTOListContainString(searchString);
                return View(modelSearch);
            }
            IEnumerable<IngredientDTO>? model = await _getIngredientService.GetIngredientDTOListAll();

            return View(model);
        }

        // GET: IngredientController/Details/5
        public async Task<ActionResult> Details(int id, string type)
        {
            ViewBag.Type = type;
            var model = await _getIngredientService.GetByIdIngredientDetailedDTO(id);
            return View(model);
        }

        public async Task<ActionResult> RedirectToIngredientDetails(string name)
        {
            var ingredientByName = await _getIngredientService.GetByNameIngredientDetailedDTO(name);

            return RedirectToAction("Details", new { id = ingredientByName.Id });
        }

        // GET: IngredientController/Create
        [Authorize(Policy = "StdUser")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngredientController/Create
        [Authorize(Policy = "StdUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IngredientDetailedDTO model)
        {
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
        [Authorize(Policy = "StdUser")]
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _getIngredientService.GetByIdIngredientEditedDTO(id);
            return View(model);
        }

        // POST: IngredientController/Edit/5
        [Authorize(Policy = "StdUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IngredientEditDTO model)
        {
            try
            {
                await _editIngredientService.Edit(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Policy = "StdUser")]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _getIngredientService.GetByIdIngredientDetailedDTO(id);
            return View(model);
        }

        // POST: Movies/Delete/name
        [Authorize(Policy = "StdUser")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _deleteIngredientService.DeleteIngredient(id);
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
        public async Task<ActionResult> Upload(IFormFile file, int id)
        {
            try
            {
                await _uploadIngredientPhotoService.AddPhoto(file, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: IngredientController/AddComment
        [Authorize(Policy = "StdUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddComment(int ingredientId, string text)
        {
            try
            {
                var userName = User.Identity.Name;

                var commentDTO = new IngredientCommentDTO
                {
                    Author = userName,
                    Text = text,
                    Date = DateTime.Now,
                    IngredientDetailsId = ingredientId
                };

                await _addCommentService.AddComment(commentDTO);

                return RedirectToAction(nameof(Details), new { id = ingredientId });
            }
            catch
            {
                return RedirectToAction(nameof(Details), new { id = ingredientId, error = "Failed to add comment" });
            }
        }


        [Authorize(Policy = "StdUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteComment(int commentId, int ingredientId)
        {
            try
            {
                var userName = User.Identity.Name;

                // Pobierz komentarz na podstawie jego identyfikatora
                var comment = await _deleteCommentService.GetCommentById(commentId);

                if (comment == null)
                {
                    return RedirectToAction(nameof(Details), new { id = ingredientId, error = "Comment not found" });
                }

                // Sprawdź, czy zalogowany użytkownik jest autorem komentarza
                if (comment.Author != userName)
                {
                    return RedirectToAction(nameof(Details), new { id = ingredientId, error = "Unauthorized action" });
                }

                // Usuń komentarz
                await _deleteCommentService.DeleteComment(commentId);

                return RedirectToAction(nameof(Details), new { id = ingredientId });
            }
            catch
            {
                // Obsługa błędu
                return RedirectToAction(nameof(Details), new { id = ingredientId, error = "Failed to delete comment" });
            }
        }

    }
}
