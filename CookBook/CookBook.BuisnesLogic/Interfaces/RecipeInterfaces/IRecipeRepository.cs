using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.Interfaces.RecipeInterfaces
{
    public interface IRecipeRepository
    {
        public IEnumerable<Recipe> GetAll();
        public Recipe GetById(int id);
        public void CreateRecipe(Recipe recipe);
        public void DeleteRecipe(int id);
        public void EditRecipe(Recipe recipe);
    }
}
