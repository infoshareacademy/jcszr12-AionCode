using CookBook.BuisnesLogic.DTO;

namespace CookBook.BuisnesLogic.Interfaces.RecipeInterfacces
{
    public interface IEditRecipeService
    {
        public Task EditRecipe(RecipeEditDTO recipeEdit);
    }
}
