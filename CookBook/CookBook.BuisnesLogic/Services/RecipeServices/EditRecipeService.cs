using CookBook.BuisnesLogic.Interfaces.RecipeInterfaces;
using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.Services.RecipeServices
{
    public class EditRecipeService(IRecipeRepository repository) : IEditRecipeService
    {
        private readonly IRecipeRepository _recipeRepository = repository;

        public void EditRecipe(Recipe recipe)
        { 
            _recipeRepository.EditRecipe(recipe);
        }


    }
}
