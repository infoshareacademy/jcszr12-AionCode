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

            var json = JsonConvert.SerializeObject(recipes);
            File.WriteAllText(path, json);
            return statusRecipe;
        }
    }
}