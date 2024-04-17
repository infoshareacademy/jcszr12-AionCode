using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database.Entities;
using Database;

namespace AionCodeMVC.Controllers
{
    public class MealDaysController : Controller
    {
        private readonly DatabaseContext  _context;

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

        // GET: MealDays/Create
        public IActionResult Create()
        {
            ViewData["UserCookBookId"] = new SelectList(_context.Set<UserCookBook>(), "Id", "Email");
            return View();
        }

        // POST: MealDays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Day,AddDate,UserCookBookId")] MealDay mealDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mealDay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserCookBookId"] = new SelectList(_context.Set<UserCookBook>(), "Id", "Email", mealDay.UserCookBookId);
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
            ViewData["UserCookBookId"] = new SelectList(_context.Set<UserCookBook>(), "Id", "Email", mealDay.UserCookBookId);
            return View(mealDay);
        }

        // POST: MealDays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Day,AddDate,UserCookBookId")] MealDay mealDay)
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
            ViewData["UserCookBookId"] = new SelectList(_context.Set<UserCookBook>(), "Id", "Email", mealDay.UserCookBookId);
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
