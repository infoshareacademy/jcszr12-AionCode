using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.MealDayServiceInterfaces;
using Database;
using Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BuisnesLogic.Services.MealDayServices
{
    public class MealDaysServices : IMealDaysServicesInterface
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private UserCookBook _cookBookUserId;
        private int _pageSize = 9;
      

        public MealDaysServices(DatabaseContext context)
        {
            _context = context;
          
        }

        public UserCookBook GetUserId(string UserIdentityName)
        {
            var resultUserId = _context.UserCookBook.Where(i => i.UserName == UserIdentityName).First();
            return resultUserId;
        }
        public async Task<IEnumerable<MealDayViewDTO>> GetAll(int? selectday, UserCookBook resultUserId)
        {

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


            IEnumerable<MealDayViewDTO> result;

            if (selectday != null)
            {

             var resultSelectday =  resultRecipeUsed.Where(u => u.UserId == resultUserId.Id && u.DayMeal.Day == selectday).OrderBy(x => x.DayMeal).ToList();
                result = resultSelectday;
    }
            else
            {
            var resultNoSelectday =  resultRecipeUsed.Where(u => u.UserId == resultUserId.Id).OrderBy(x => x.DayMeal).ToList();
            result = resultNoSelectday;
            }
            return result;

        }

        public async Task<MealDayDTO> CreatePost(MealDay mealDay, RecipeUsed recipeUsed, MealDayDTO mealDayDTO)
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
            return mealDayDTO;

        }

        public async Task<MealDay> Delete(int? id)
        {
            var mealDay = await _context.MealDay
                 .Include(m => m.UserCookBook)
                 .FirstOrDefaultAsync(m => m.Id == id);
            return mealDay;
        }
        public Task Details(int? id)
        {
            var result = _context.MealDay
                 .Include(m => m.UserCookBook)
                 .FirstOrDefaultAsync(m => m.Id == id);
            return result;
        }

        public async Task<MealDay?> Edit(int? id)
        {
            var result = _context.MealDay.FindAsync(id);
            return await result;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteConfirmed(int id)
        {
            var mealDay = await _context.MealDay.FindAsync(id);
            var recipeUsed = await _context.RecipeUsed.FirstOrDefaultAsync(m => m.MealDayId == id);

            if (mealDay != null && recipeUsed != null)
            {
                _context.RecipeUsed.Remove(recipeUsed);
                _context.MealDay.Remove(mealDay);

            }

            await _context.SaveChangesAsync();

        }
        private bool MealDayExists(int id)
        {
            return _context.MealDay.Any(e => e.Id == id);
        }

        public Task<MealDayDTO> CreateGet(int p, UserCookBook cookBookUserId)
        {
            int page = (int)((p == null) ? 1 : p);

            var result = _context.UserCookBook.Where(i => i.UserName == cookBookUserId.UserName)
                                                .Select(a => new { a.Id }).ToList();

            var resultRecipes = _context.RecipeDetails
                                        .Select(i => new RecipesDetailsShortDTO
                                        { Id = i.Id, Name = i.Name, ImagePath = i.ImagePath }).Skip((page - 1) * _pageSize).Take(_pageSize).ToList();
            var mealDayDTO = new MealDayDTO { AddDate = DateTime.Now, DetailsShort = resultRecipes };


            return Task.FromResult(mealDayDTO);
        }
        public Task<int> LongList()
        {
            var result = _context.RecipeDetails.Count() / _pageSize;
            return Task.FromResult(result);
        }
    }
}
