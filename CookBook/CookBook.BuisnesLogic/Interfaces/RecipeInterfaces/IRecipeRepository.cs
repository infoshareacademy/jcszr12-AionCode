using Azure.Storage.Blobs;
using CookBook.BuisnesLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Management.Storage.Models;

namespace CookBook.BuisnesLogic.Interfaces.RecipeInterfaces
{
    public interface IRecipeRepository
    {
        public IEnumerable<Recipe> GetAll();
        public Recipe GetById(int id);
        public void CreateRecipe(int id, Recipe recipe, IFormFile file);
        public void DeleteRecipe(int id);
        public void UpdateRecipe(int id, Recipe recipe);
        
        
    }
}
