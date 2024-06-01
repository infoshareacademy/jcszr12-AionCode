using CookBook.BuisnesLogic.DTO;
using Database;
using Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AionCodeMVC.Controllers
{
    public class MealDaysController : Controller
    {
        private readonly DatabaseContext _context;

        public MealDaysController(DatabaseContext dbContext)
        {
            _context = dbContext;
        }

        // GET: MealDays
        public async Task<IActionResult> Index()
        {
            var aionCodeDatabase = _context.MealDay.Include(m => m.UserCookBook);
            return View(await aionCodeDatabase.ToListAsync());
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
        public IActionResult Create()
        {

            var result = _context.UserCookBook  .Where(i => i.UserName == User.Identity.Name)
                                                .Select(a => new { a.Id }).ToList();

            ViewData["UserCookBook"] = result[0].Id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Day, UserCookBookId, PartOfDay, RecipeDetailsId")] MealDayDTO mealDayDTO)
        {

            var mealDay = new MealDay();
            var recipeUsed= new RecipeUsed();
            int maxIdMealDay = _context.MealDay.Max(md => md.Id) + 1;

            if (ModelState.IsValid)
            {

                mealDay.Day = mealDayDTO.Day;
                mealDay.AddDate = DateTime.Now;
                mealDay.UserCookBookId = mealDayDTO.UserCookBookId.ToString();

                recipeUsed.AddDate = DateTime.Now;
                recipeUsed.MealDayId = maxIdMealDay;
                recipeUsed.PartOfDay = mealDayDTO.PartOfDay;
                recipeUsed.RecipeDetailsId = mealDayDTO.RecipeDetailsId;


                _context.Add(mealDay);
                _context.Add(recipeUsed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserCookBook"] = mealDay.UserCookBookId;
            return View(mealDay);
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
            // ViewData["UserCookBookId"] = new SelectList(_context.Set<UserCookBook>(), "Id", "Email", mealDay.UserCookBookId);
            return View(mealDay);
        }

        // POST: MealDays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            if (mealDay != null)
            {
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
