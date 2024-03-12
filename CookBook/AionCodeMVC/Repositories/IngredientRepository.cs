﻿using AionCodeMVC.Interfaces;
using AionCodeMVC.Models;
using Newtonsoft.Json;
using System.IO;

namespace AionCodeMVC.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private static string path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "ingredients.json");
        public IEnumerable<Ingredient> GetAll()
        {
            return ReadIngredientsFomJson();
        }
        public Ingredient GetByID(int id)
        {
            return ReadIngredientsFomJson().FirstOrDefault(x=> x.Id == id);
        }
        private static List<Ingredient> ReadIngredientsFomJson()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            var ingredientAllSerialize = File.ReadAllText(path);
            var ingredientList = JsonConvert.DeserializeObject<List<Ingredient>>(ingredientAllSerialize);
            if (ingredientList == null)
            {
                ingredientList = new List<Ingredient>();
            }
            return ingredientList;
        }

        public void CreateIngredient(Ingredient ingredient)
        {
            var ingredients = GetAll().ToList();
            if (!ingredients.Any(i => i.Name == ingredient.Name || i.Id == ingredient.Id))
            {
                ingredient.Id = ingredients.Count() + 1;
                ingredients.Add(ingredient);
            }
            var json = JsonConvert.SerializeObject(ingredients);
            File.WriteAllText(path, json);
        }





        /*        public static bool RecipeAdd(Recipe newRecipe)
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
        }*/

    }
}
