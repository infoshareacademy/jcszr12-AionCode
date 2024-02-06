using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CookBook.BuisnesLogic.Exceptions;
using CookBook.BuisnesLogic.Models;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;


namespace CookBook.BuisnesLogic.Services
{
    public static class AddRecipe

    {
        private static string path = PathProviderRecipe.GetRecipeFile();
        public static List<Recipe> GetRecipe()
        {
            CreateRecipeFile();
            var recipeAllSerialise = File.ReadAllText(path);
            var recipe = JsonConvert.DeserializeObject<List<Recipe>>(recipeAllSerialise);
            if (recipe == null)
            {
                recipe = new List<Recipe>();
            }
            return recipe;
        }
        public static bool RecipeAdd(Recipe newRecipe)
        {
            bool statusRecipe = false;
            var recipes = GetRecipe();

            if (!recipes.Any(i => i.Name == newRecipe.Name || i.Id == newRecipe.Id))
            {
                newRecipe.Id = recipes.Count() + 1;
                recipes.Add(newRecipe);
                statusRecipe = true;

            }
            else 
            {
                throw new ExceptionAddRecipe();
            }

            var json = JsonConvert.SerializeObject(recipes);
            File.WriteAllText(path, json);
            return statusRecipe;
        }
        private static void CreateRecipeFile()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
        }

    }
}
