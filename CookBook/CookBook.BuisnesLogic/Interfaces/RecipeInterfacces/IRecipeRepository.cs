using CookBook.BuisnesLogic.Models;
using Microsoft.AspNetCore.Http;

namespace CookBook.BuisnesLogic.Interfaces.RecipeInterfacces
{
    public interface IRecipeRepository
    {
        public IEnumerable<Recipe> GetAll();
        public Recipe GetByID(int id);
        public void CreateRecipe(Recipe recipe);
        public void DeleteRecipe(int id);
        public void Edit(Recipe recipe);
        public string AddPhoto(IFormFile file, int id);

    }
}
