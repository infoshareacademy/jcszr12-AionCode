using CookBook.BuisnesLogic.DTO;
using Database;
using Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.IO.Hashing;

namespace AionCodeMVC.Controllers
{
    public class MealDaysController : Controller
    {
        private readonly DatabaseContext _context;
        private UserCookBook _resultUserId;

        public MealDaysController(DatabaseContext dbContext)
        {
            _context = dbContext;
        }

        // GET: MealDays
        public async Task<IActionResult> Index(int? selectday)
        {
            
            try
            {
            _resultUserId = _context.UserCookBook.Where(i => i.UserName == User.Identity.Name).First();
            }
            catch
            {
                return RedirectToAction(nameof(Login), "Users");
            }
            

            var resultRecipeUsed = await _context.MealDay.Join(_context.RecipeUsed, t1 => t1.Id, t2 => t2.MealDayId,
                                    (t1, t2) => new
                                    {
                                        MealDayId = t1.Id,
                                        UserId = t1.UserCookBookId,
                                        DayMeal = t1.Day,
                                        RecipeMeal = t2.PartOfDay,
                                        RecipeUsedId = t2.RecipeDetailsId
                                    }
                ).Join(_context.RecipeDetails, x2 => x2.RecipeUsedId, x3 => x3.Id, (t, t3) => new MealDayViewDTO
                {
                    MealDayId = t.MealDayId,
                    UserId = t.UserId,
                    DayMeal = t.DayMeal,
                    RecipeMeal = t.RecipeMeal,
                    RecipeUsedId = t.RecipeUsedId,
                    RecipeName = t3.Name

                }).ToListAsync();

            if (selectday != null)
            {
                TempData["selectday"] = selectday;
                return View(resultRecipeUsed.Where(u => u.UserId == _resultUserId.Id && u.DayMeal.Day == selectday).OrderBy(x => x.DayMeal));
            }
            else
            {
                return View(resultRecipeUsed.Where(u => u.UserId == _resultUserId.Id).OrderBy(x => x.DayMeal));
            }
        }

        // GET: MealDays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealDay = await _context.MealDay
                .Include(m => m.UserCookBook)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mealDay == null)
            {
                return NotFound();
            }

            return View(mealDay);
        }

        [HttpGet]
        public IActionResult Create(int? str)
        {

            var result = _context.UserCookBook  .Where(i => i.UserName == User.Identity.Name)
                                                .Select(a => new { a.Id }).ToList();

            var resultRecipes = _context.RecipeDetails
                                        .Select(i => new RecipesDetailsShortDTO 
                                        { Id = i.Id, Name = i.Name, ImagePath = i.ImagePath }).ToList();
            var mealDayDTO = new MealDayDTO { AddDate = DateTime.Now, DetailsShort = resultRecipes };
            
            ViewData["UserCookBook"] = result[0].Id;
            return View(mealDayDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Day, UserCookBookId, PartOfDay, RecipeDetailsId, DetailsShort")] MealDayDTO mealDayDTO)
        {

            var mealDay = new MealDay();
            var recipeUsed= new RecipeUsed();
            

            if (ModelState.IsValid)
            {

                mealDay.Day = mealDayDTO.Day;
                mealDay.AddDate = DateTime.Now;
                mealDay.UserCookBookId = mealDayDTO.UserCookBookId.ToString();

                _context.Add(mealDay);
                await _context.SaveChangesAsync();

                recipeUsed.AddDate = DateTime.Now;
                recipeUsed.MealDayId = _context.MealDay.Max(md => md.Id);
                recipeUsed.PartOfDay = mealDayDTO.PartOfDay;
                recipeUsed.RecipeDetailsId = mealDayDTO.RecipeDetailsId;

                _context.Add(recipeUsed);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["UserCookBook"] = mealDay.UserCookBookId;
            return View(mealDayDTO);
        }

        // GET: MealDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealDay = await _context.MealDay.FindAsync(id);
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
            if (id != mealDay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(mealDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealDayExists(mealDay.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserCookBookId"] = mealDay.UserCookBookId;
            return View(mealDay);
        }

        // GET: MealDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealDay = await _context.MealDay
                .Include(m => m.UserCookBook)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var mealDay = await _context.MealDay.FindAsync(id);
            var recipeUsed = await _context.RecipeUsed.FirstOrDefaultAsync(m => m.MealDayId == id);

            if (mealDay != null && recipeUsed != null)
            {
                _context.RecipeUsed.Remove(recipeUsed);
                _context.MealDay.Remove(mealDay);
              
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealDayExists(int id)
        {
            return _context.MealDay.Any(e => e.Id == id);
        }
    }
}
