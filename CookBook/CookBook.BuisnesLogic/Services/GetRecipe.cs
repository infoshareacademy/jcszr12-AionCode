using CookBook.BuisnesLogic.Exceptions;
using CookBook.BuisnesLogic.Models;

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
