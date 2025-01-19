using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.TempTestUI
{
    public class AddedRecipeTest
    {
        public static string GetName()
        {
            Console.WriteLine("Enter dish name: ");
            string name = Console.ReadLine();
            return name;
        }
        public static string GetCategory()
        {
            Console.WriteLine("Enter dish category:");
            string category = Console.ReadLine();
            return category;
        }
        public static string GetDescription()
        {
            Console.WriteLine("Enter dish description:");
            string description = Console.ReadLine();
            return description;
        }
        public static List<string> GetIngredientList()
        {
            Console.WriteLine("Enter dish ingrendient list:");
            List<string> ingredientList = new List<string>();
            while (true)
            {
                Console.WriteLine("Enter dish ingrendient list:\n Or press / to end");
                string ingredient = Console.ReadLine();
                if (ingredient == "/")
                {
                    break;
                }
                ingredientList.Add(ingredient);
            }
            return ingredientList;
        }
        public static void ShowAllRecipe(List<Recipe> recipes)
        {
            Console.WriteLine("\n\n");
            foreach (Recipe recipe in recipes)
            {
                Console.WriteLine(@"Lista przepisów", recipe.Name, recipe.Category, recipe.Description);
            }
        }
    }
}
