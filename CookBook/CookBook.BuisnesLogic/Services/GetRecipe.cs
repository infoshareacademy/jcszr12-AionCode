using CookBook.BuisnesLogic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.BuisnesLogic.Services;

namespace CookBook.BuisnesLogic.Services
{
    public class GetRecipe //Mariusz
    {

        private static Random random = new Random();

        //Returns random recipe using other service (GetRecipeList) to acces all recipes.
        public static Recipe GetRandomRecipe()
        {
            var recipes = GetRecipeList.ReadRecipesFromFile();
            return recipes[random.Next(recipes.Count)];
        }


        //Zwraca przepis nr: 
        public static Recipe GetRecipeNumber(int ID)
        {
            var recipes = GetRecipeList.ReadRecipesFromFile();
            if (recipes.Count == 0)
            {
                // to do:
                // throw new Exception() ArgumentOutOfRangeException ??
            }
            var recipe = recipes.FirstOrDefault(x => x.Id == ID);
            if (recipe == null) throw new Exception();


            return recipe;
        }

    }
}
