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
        private UserCookBook _resultUserId;

        public MealDaysController(IMealDaysServicesInterface mealDay)
        {
            _mealday = mealDay;
           
        }

        // GET: MealDays
        public async Task<IActionResult> Index(int? selectday)
        {
            try
            {
                _resultUserId = _mealday.GetUserId(User.Identity.Name);
            }
            catch
            {
                return RedirectToAction(nameof(Login), "Users");
            }

            if (selectday != null)
            {
                TempData["selectday"] = selectday;
                IEnumerable<MealDayViewDTO> result = await _mealday.GetAll(selectday, _resultUserId);
                return View(result);
            }
            else
            {
                IEnumerable<MealDayViewDTO> result = await _mealday.GetAll(null,_resultUserId);
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
        public IActionResult Create(int p)
        {
            var mealDayDTO = _mealday.CreateGet(p, _resultUserId);
            ViewData["UserCookBook"] = _mealday.GetUserId(User.Identity.Name);
            TempData["page"] = p;
            TempData["longList"] = 2;

            return View(mealDayDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Day, UserCookBookId, PartOfDay, RecipeDetailsId, DetailsShort")] MealDayDTO mealDayDTOin)
        {

            var mealDay = new MealDay();
            var recipeUsed = new RecipeUsed();


            if (ModelState.IsValid)
            {
                _mealday.CreatePost(mealDay, recipeUsed, mealDayDTOin);

                return RedirectToAction(nameof(Index));
            }
            ViewData["UserCookBook"] = mealDay.UserCookBookId;
            return View(mealDayDTOin);
        }

        // GET: MealDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealDay = _mealday.Edit(id);
            if (mealDay == null)
            {
                return NotFound();
            }
            return View(mealDay);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Day,AddDate,UserCookBookId")] MealDay mealDay)
        {
            //if (id != mealDay.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{

            //    try
            //    {
            //        _context.Update(mealDay);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!MealDayExists(mealDay.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["UserCookBookId"] = mealDay.UserCookBookId;
            return View(mealDay);
        }

        // GET: MealDays/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealDay = _mealday.Delete(id);
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
            _mealday.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
