using CookBook.BuisnesLogic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CookBook.BuisnesLogic.Services
{
    public class GetRecipeList //Mariusz
    {
        private static string path = PathProviderRecipe.GetRecipeFile();

        public static List<Recipe> ReadRecipesFromFile()
        {
            CreateDataFileIfFileDoesntExist();

            var recipeAllSerialise = File.ReadAllText(path);
            var recipesList = JsonConvert.DeserializeObject<List<Recipe>>(recipeAllSerialise);
            if (recipesList == null)
            {
                recipesList = new List<Recipe>();
            }
            return recipesList;
        }
        
        public static void SaveRecipeToFile(Recipe recipe)
        {
            var recipesList = ReadRecipesFromFile();
            recipesList.Add(recipe);
            var recipesJson = JsonConvert.SerializeObject(recipesList);
            File.WriteAllText(path, recipesJson);
        }

        private static void CreateDataFileIfFileDoesntExist()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
        }
    }
}
