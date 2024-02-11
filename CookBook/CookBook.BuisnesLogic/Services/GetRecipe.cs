using CookBook.BuisnesLogic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.BuisnesLogic.Services;
using CookBook.BuisnesLogic.Exceptions;

namespace CookBook.BuisnesLogic.Services
{
    public class GetRecipe //Mariusz
    {

        private static Random random = new Random();

        public static Recipe GetRandomRecipe()
        {
            var recipes = GetRecipeList.ReadRecipesFromFile();
            if (recipes.Count == 0) throw new ExceptionRecipeNot();
            return recipes[random.Next(recipes.Count)];
        }


        //Zwraca przepis nr ID: 
        public static Recipe GetRecipeNumber(int ID)
        {
            var recipes = GetRecipeList.ReadRecipesFromFile();
            var recipe = recipes.FirstOrDefault(x => x.Id == ID);
            if (recipe == null || recipes.Count == 0) throw new ExceptionRecipeNot();
            return recipe;
        }

    }
}
