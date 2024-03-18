using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.Interfaces.RecipeInterfaces
{
    public interface IGetRecipeService
    {
        public IEnumerable<Recipe> GetAllRecipe();
        public Recipe GetById(int id);
    }
}
