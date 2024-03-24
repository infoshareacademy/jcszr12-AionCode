using CookBook.BuisnesLogic.Models;
using Newtonsoft.Json;

namespace CookBook.BuisnesLogic.Repositories.RecipeRepository
{
    public class LoadRecipe
    {
        private static string path = RecipeReader.GetRecipeFile();
        public static IList<Recipe> ReadRecipeFromJson() 
        {
            CreateFilIfDoesntExist();

            var recipeAllSerialize = File.ReadAllText(path);
            var recipeList = JsonConvert.DeserializeObject<IList<Recipe>>(recipeAllSerialize);
            if (recipeList == null)
            { 
                recipeList = [];
            }

            return recipeList;
        }

        private static void CreateFilIfDoesntExist()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
        }
    }
}
