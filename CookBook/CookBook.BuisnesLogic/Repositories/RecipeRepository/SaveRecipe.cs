using CookBook.BuisnesLogic.Models;
using Newtonsoft.Json;

namespace CookBook.BuisnesLogic.Repositories.RecipeRepository
{
    public class SaveRecipe
    {
        private static string path = RecipeReader.GetRecipeFile();
        internal static void SaveRecipeToJson(Recipe recipe)
        { 
            var recipeList = LoadRecipe.ReadRecipeFromJson();
            recipeList.Add(recipe);
            var recipesJson = JsonConvert.SerializeObject(recipeList, Formatting.Indented);
            File.WriteAllText(path, recipesJson);
        }
    }
}
