using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.MealDayServiceInterfaces;
using Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace AionCodeMVC.Controllers
{
    public class MealDaysController : Controller
    {
        private readonly IMealDaysServicesInterface _mealday;
        private UserCookBook _actualUser;

        public MealDaysController(IMealDaysServicesInterface mealDay)
        {
            _mealday = mealDay;
            
        }

        // GET: MealDays
        public async Task<IActionResult> Index(int? selectday)
        {
            try
            {
                _actualUser = _mealday.GetUserId(User.Identity.Name);
            }
            catch
            {
                return RedirectToAction(nameof(Login), "Users");
            }

            if (selectday != null)
            {
                TempData["selectday"] = selectday;
                IEnumerable<MealDayViewDTO> result = await _mealday.GetAll(selectday, _actualUser);
                return View(result);
            }
            else
            {
                IEnumerable<MealDayViewDTO> result = await _mealday.GetAll(null,_actualUser);
                return View(result);
            }
        }

        // GET: MealDays/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealDay = _mealday.Details(id);
            if (mealDay == null)
            {
                return NotFound();
            }

            return View(mealDay);
        }


        [HttpGet]
        public async Task<IActionResult> Create(int? p)
        {
            try
            {
                _actualUser = _mealday.GetUserId(User.Identity.Name);
            }
            catch
            {
                return RedirectToAction(nameof(Login), "Users");
            }
            MealDayDTO mealDayDTO = await _mealday.CreateGet(p, _actualUser.Id);
            ViewData["UserCookBook"] = _actualUser.Id;
            TempData["page"] = p;
            TempData["longList"] = _mealday.LongList();

            return View(mealDayDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Day, UserCookBookId, PartOfDay, RecipeDetailsId, DetailsShort")] MealDayDTO mealDayDTO)
        {
            if (ModelState.IsValid)
            {
                var mealDay = new MealDay();
                var recipeUsed = new RecipeUsed();
                await _mealday.CreatePost(mealDay, recipeUsed, mealDayDTO);

                return RedirectToAction(nameof(Index));
            }
            ViewData["UserCookBook"] = _actualUser.Id;
            return View(mealDayDTO);
        }

        // GET: MealDays/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var mealDay = await _mealday.Edit(id);
            return View(mealDay);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(MealDay mealDay)
        {

            //if (ModelState.IsValid)
            //{
                try
                {
                    await _mealday.EditConfirmed(mealDay);
               
                }
                catch 
                {
                        return NotFound();
                }
                
           // }
            ViewData["UserCookBookId"] = mealDay.UserCookBookId;
            return RedirectToAction(nameof(Index));
        }

        private bool MealDayExists(int id)
        {
            throw new NotImplementedException();
        }

        // GET: MealDays/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealDay = await _mealday.Delete(id);
            if (mealDay == null)
            {
                return NotFound();
            }
            return View(mealDay);
        }

        // POST: MealDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mealday.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
