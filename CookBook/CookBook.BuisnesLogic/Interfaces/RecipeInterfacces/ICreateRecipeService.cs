using CookBook.BuisnesLogic.DTO;

namespace CookBook.BuisnesLogic.Interfaces.RecipeInterfacces
{
    public interface ICreateRecipeService
    {
        public Task CreateRecipe(RecipeDetailsDTO recipe);
    }
}
