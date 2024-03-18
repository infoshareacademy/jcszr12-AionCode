using CookBook.BuisnesLogic.Interfaces.RecipeInterfaces;
using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.Services.RecipeServices
{
    public class CreateRecipeService(IRecipeRepository recipeRepository) : ICreateRecipeService
    {
        private readonly IRecipeRepository _recipeRepository = recipeRepository;

        public void CreateRecipe(Recipe recipe) 
        {
            _recipeRepository.CreateRecipe(recipe);
        }
    }
}
