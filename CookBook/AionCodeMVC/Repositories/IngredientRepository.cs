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

        public void DeleteIngredient(int id)
        {
            var ingredients = GetAll().ToList();
            var ingredientToDelete = ingredients.FirstOrDefault(r => r.Id == id);
            if (ingredientToDelete != null)
            {
                ingredients.Remove(ingredientToDelete);
            }
            var json = JsonConvert.SerializeObject(ingredients);
            File.WriteAllText(path, json);

        }

        public void Edit(Ingredient ingredient)
        {
            var ingredients = GetAll().ToList();
            var ingredientToEdit = ingredients.FirstOrDefault(r => r.Id == ingredient.Id);

            if (ingredientToEdit!=null)
            {
                ingredientToEdit.Price = ingredient.Price;
                ingredientToEdit.Carbohydrates = ingredient.Carbohydrates;
                ingredientToEdit.Proteins = ingredient.Proteins;
                ingredientToEdit.Calories = ingredient.Calories;
                ingredientToEdit.Description = ingredient.Description;
                ingredientToEdit.Fats = ingredient.Fats;
                ingredientToEdit.Name = ingredient.Name;
                ingredientToEdit.Type = ingredient.Type;
            }

            var json = JsonConvert.SerializeObject(ingredients);
            File.WriteAllText(path, json);

        }



    }
}
