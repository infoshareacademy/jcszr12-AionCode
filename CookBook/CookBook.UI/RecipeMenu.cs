using CookBook.BuisnesLogic.Services;
using CookBook.BuisnesLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CookBook.UI
{
    public static class RecipeMenu
    {
        public static Recipe ChooseRecipeFromList()
        {
            List<Recipe> recipes = new();
            recipes = GetRecipeList.ReadRecipesFromFile();

            Console.Clear();
            Menu RecipeMenu = new Menu("Lista przepisów - wskaż wybrany aby zobaczyć szczegóły:");
            
            foreach (Recipe recipe in recipes)
            {
                RecipeMenu.AddPosition(recipe.Name, recipe.Id.ToString());
            }
            RecipeMenu.ShowMenu();
            RecipeMenu.OptionSelect();
            return recipes[RecipeMenu.CurrentMenuPosition];
        }

        public static void ShowRecipe()
        {
            Recipe recipe = ChooseRecipeFromList();
            recipe = GetRecipe.GetRecipeNumber(recipe.Id);

            Console.Clear();
            Console.WriteLine($"Przepis na {recipe.Name}\n");
            Console.WriteLine($"Składniki:\n");

            foreach (var ingredient in recipe.IngredientList)
            {
                Console.WriteLine(ingredient);
            }

            Console.WriteLine($"\nTreść przepisu:\n{recipe.Description}\n");
            Console.WriteLine("\nWciśnij dowolny klawisz, aby wrócić do menu.");
            
            Console.ReadKey();
        }

        public static void RecipeAdd()
        {
            Recipe recipe = new();
            int i = 0;
            string[] ingredients;

            Console.Clear();
            Console.WriteLine("Kreator dodawania przepisu do książki kucharskiej.\n");
            Console.Write("Kategoria potrawy: "); recipe.Category = Console.ReadLine();
            Console.Write("Nazwa potrawy: "); recipe.Name = Console.ReadLine();
            Console.Write("Składniki potrawy (oddziel składniki przecinkiem): "); ingredients = Console.ReadLine().Split(',');
            for (int ii = 0; ii < ingredients.Length; ii++) ingredients[ii] = ingredients[ii].Trim(); recipe.IngredientList = new List<string>(ingredients);
            Console.Write("Opis potrawy: "); recipe.Description = Console.ReadLine();

            try
            {
                AddRecipe.RecipeAdd(recipe);
                Console.WriteLine("\nDodano Twój przepis do Listy Przepisów AionCode!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n{ex.Message}");
            }
          

            Console.WriteLine("\nWciśnij dowolny klawisz, aby wrócić do menu.");

            Console.ReadKey();
        }

        public static void RecipeRemove()
        {
            Recipe recipe = ChooseRecipeFromList();
            recipe = GetRecipe.GetRecipeNumber(recipe.Id);

            try
            {
                DeleteRecipe.RecipeDelete(recipe.Id);
            }
            catch (Exception ex) { Console.WriteLine($"\n{ex.ToString()}"); }

            Console.WriteLine("\nWciśnij dowolny klawisz, aby wrócić do menu.");

            Console.ReadKey();
        }
    }
}
