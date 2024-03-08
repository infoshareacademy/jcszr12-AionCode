using CookBook.BuisnesLogic.Exceptions;
using Newtonsoft.Json;

namespace CookBook.BuisnesLogic.Services
{
    public static class DeleteRecipe
    {
        private static string path = PathProviderRecipe.GetRecipeFile();

        public static bool RecipeDelete(int id)
        {
            bool statusRecipe = false;
            var recipes = AddRecipe.GetRecipe();

            var recipeToDelete = recipes.FirstOrDefault(r => r.Id == id);

            if (recipeToDelete != null)
            {
                recipes.Remove(recipeToDelete);
                statusRecipe = true;
            }
            else 
            {
                throw new ExceptionRecipeNot();
            }

            var json = JsonConvert.SerializeObject(recipes, Formatting.Indented);
            File.WriteAllText(path, json);
            return statusRecipe;
        }
    }
}