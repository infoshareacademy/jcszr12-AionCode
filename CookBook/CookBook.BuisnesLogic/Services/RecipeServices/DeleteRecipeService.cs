using CookBook.BuisnesLogic.Interfaces.RecipeInterfaces;

namespace CookBook.BuisnesLogic.Services.RecipeServices
{
    public class DeleteRecipeService(IRecipeRepository recipeRepository) : IDeleteRecipeService
    { 
        private readonly IRecipeRepository _recipeRepository = recipeRepository;

        public void DeleteRecipe(int id) 
        {
            _recipeRepository.DeleteRecipe(id);
        }
    }
}
