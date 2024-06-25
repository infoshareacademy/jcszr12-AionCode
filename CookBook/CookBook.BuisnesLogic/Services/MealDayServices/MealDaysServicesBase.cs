using CookBook.BuisnesLogic.DTO;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BuisnesLogic.Services.MealDayServices
{
    public class MealDaysServicesBase
    {
        private readonly DatabaseContext _context;
        private int _pageSize = 9;
        private UserCookBook _resultUserId;


        public async Task<MealDayViewDTO> GetAll(int? selectday)
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

            if (selectday != null)
            {

                return var result = await resultRecipeUsed.Where(u => u.UserId == _resultUserId.Id && u.DayMeal.Day == selectday).OrderBy(x => x.DayMeal);
            }
            else
            {
                var result = resultRecipeUsed.Where(u => u.UserId == _resultUserId.Id).OrderBy(x => x.DayMeal);
            }
        }
    }
}