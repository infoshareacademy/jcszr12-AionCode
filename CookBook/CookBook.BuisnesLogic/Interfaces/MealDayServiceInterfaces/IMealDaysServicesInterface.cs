using CookBook.BuisnesLogic.DTO;
using Database.Entities;

namespace CookBook.BuisnesLogic.Interfaces.MealDayServiceInterfaces
{
    public interface IMealDaysServicesInterface
    {
        public UserCookBook GetUserId(string UserIdentityName);
        public Task<IEnumerable<MealDayViewDTO>> GetAll(int? selectday, UserCookBook resultUserId);
        public Task Delete(int id);
        public Task DeleteConfirmed(int id);
        public Task Details(int? id);
        public Task<MealDay> Edit(int? id);
        public Task<MealDayDTO> CreateGet(int p, UserCookBook resultUserId);
        public Task<MealDayDTO> CreatePost(MealDay mealDay, RecipeUsed recipeUsed, MealDayDTO mealDayDTO);
        public Task<int> LongList();


    }
}
