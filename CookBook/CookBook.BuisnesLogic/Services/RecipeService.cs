using CookBook.BuisnesLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Services
{
    public class RecipeService
    {
        private static int _idCounter = 0;
        private readonly List<Recipe> _recipe = GetRecipeList.ReadRecipesFromFile();

        public List<Recipe> GetAll() 
        {
            return _recipe;
        }
        public Recipe GetById(int id) 
        {
            return _recipe.FirstOrDefault(x => x.Id == id);
        }
        public Recipe GetMaxId(int id) 
        {
            return _recipe.Where(x => x.Id == id).Max();
        }
        public void Create(Recipe recipe) 
        {
            recipe.Id = GetNextId();
            _recipe.Add(recipe);
        }
        public void Update(Recipe model) 
        {
            var recipe = GetById(model.Id);

            recipe.Name = model.Name;
            recipe.Category = model.Category;
            recipe.Description = model.Description;
            //recipe.IngredientList = model.IngredientList;
        }

        private int GetNextId()
        {
            _idCounter++;
            return _idCounter;
        }
    }
}
