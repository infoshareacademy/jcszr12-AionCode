﻿using CookBook.BuisnesLogic.Models;
using Newtonsoft.Json;


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

        private static void CreateDataFileIfFileDoesntExist()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
        }
    }
}
