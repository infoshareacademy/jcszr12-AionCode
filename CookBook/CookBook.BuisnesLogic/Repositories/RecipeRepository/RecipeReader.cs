namespace CookBook.BuisnesLogic.Repositories.RecipeRepository
{
    public class RecipeReader
    {
        public static string GetRecipeFile()
        {
            return Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "dataRecipes.json");
        }
    }
}
