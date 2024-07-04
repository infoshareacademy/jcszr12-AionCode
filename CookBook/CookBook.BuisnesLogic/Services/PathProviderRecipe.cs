namespace CookBook.BuisnesLogic.Services;

public static class PathProviderRecipe
{
    public static string GetRecipeFile()
    {
        return Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "dataRecipes.json");
    }
}
