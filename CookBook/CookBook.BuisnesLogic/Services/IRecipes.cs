
namespace CookBook.BuisnesLogic.Services
{
    public interface IShowAllRecipe
    {
        void DisplayAllRecipes(IEnumerable<Przepisy> recipes);
    }
    public interface IShowSelectedRecipe
    { 
        void ShowSelectedRecipe();
    }
    public interface IAddRecipe
    {
        void AddRecipe();
    }
}