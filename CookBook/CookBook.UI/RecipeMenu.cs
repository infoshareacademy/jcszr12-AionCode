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
        public static void ShowRecipeList()
        {
            List<Recipe> recipes = new();
            recipes = GetList(); // zamienić na serwis

            Console.Clear();
            Menu RecipeMenu = new Menu("Lista przepisów - wskaż wybrany aby zobaczyć szczegóły:");
            
            foreach (Recipe recipe in recipes)
            {
                RecipeMenu.AddPosition(recipe.Name, recipe.Id.ToString());
            }
            RecipeMenu.ShowMenu();
            RecipeMenu.OptionSelect();
            ShowRecipe(recipes[RecipeMenu.CurrentMenuPosition].Id);
        }

        public static void ShowRecipe(int receipeId)
        {
            Recipe recipe = new();
            recipe = GetRecipeTemp(); // zamienić na serwis

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

        public static void AddRecipe()
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

            //            PutRecipe(); // zamienić na serwis

            Console.WriteLine("\nWciśnij dowolny klawisz, aby wrócić do menu.");

            Console.ReadKey();
        }

        public static List<Recipe> GetList()
        {
            List<Recipe> recipes = new();

            recipes.Add(new Recipe { 
                Id = 1,
                Name = "Przepis1",
                Category = "dania obiadowe",
                Description = "1. W garnku gotuj wod� i gotuj spaghetti wed�ug wskaz�wek na opakowaniu.\n2. W drugim garnku podsma� cebul� i czosnek na",
                IngredientList = new List<string> { "1. Cebula", "2. Pietruszka" }});

            recipes.Add(new Recipe {
                Id = 2,
                Name = "Przepis2",
                Category = "dania obiadowe",
                Description = "1. W drugim garnku podsma� cebul� i czosnek na",
                IngredientList = new List<string> { "1. Czosnek", "2. Cebula", "3. papryka" }});

            return recipes;
        }

        public static Recipe GetRecipeTemp()
        {
            Recipe recipe = new();
            
            recipe.Id = 2;
            recipe.Name = "Przepis1";
            recipe.Category = "dania obiadowe";
            recipe.Description = "1. W garnku gotuj wod� i gotuj spaghetti wed�ug wskaz�wek na opakowaniu.\n2. W drugim garnku podsma� cebul� i czosnek na";
            recipe.IngredientList = new List<string> { "1. Cebula", "2. Pietruszka" };

            return recipe;
        }
    }
}
