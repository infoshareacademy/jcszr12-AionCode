using CookBook.BuisnesLogic.Models;
using System.Collections.Generic;

namespace CookBook.BuisnesLogic.Services
{
    public class RecipeService : IRecipeService
    {
        private static int _idCounter = 3;
        private readonly IList<Recipe> _recipe = GetRecipeList.ReadRecipesFromFile();

        public IEnumerable<Recipe> GetAll() 
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
            GetRecipeList.SaveRecipeToFile(recipe);
        }
        public bool Update(int id, Recipe model) 
        {
            var recipe = GetById(model.Id);

            recipe.Name = model.Name;
            recipe.Category = model.Category;
            recipe.Description = model.Description;
            recipe.IngredientList = model.IngredientList;

            return true;
        }

        private int GetNextId()
        {
            //GetMaxId(); ???? 
            _idCounter++;
            return _idCounter;
        }

        public bool DeleteById(int id)
        {
            return _recipe.Remove(GetById(id));
        }

        Recipe IRecipeService.Create(Recipe newRecipe)
        {
            newRecipe.Id = _recipe.Max(recipe => recipe.Id) + 1;
            _recipe.Add(newRecipe);

            return newRecipe;
        }
    }
}
