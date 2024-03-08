using CookBook.BuisnesLogic.Models;
using System.Collections.Generic;

namespace CookBook.BuisnesLogic.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IList<Recipe> _recipe = GetRecipeList.ReadRecipesFromFile();

        public IEnumerable<Recipe> GetAll() 
        {
            return _recipe;
        }
        public Recipe GetById(int id) 
        {
            return _recipe.FirstOrDefault(x => x.Id == id);
        }
        public void Create(Recipe recipe) 
        { 
            recipe.Id = _recipe.Max(x => x.Id) + 1; 
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
        public bool DeleteById(int id)
        {
            var recipeToRemove = GetById(id);
            if (recipeToRemove != null)
            {
                _recipe.Remove(recipeToRemove);
                DeleteRecipe.RecipeDelete(recipeToRemove.Id);
                return true;
            }
            else
            {
                return false;
            }
        }

        Recipe IRecipeService.Create(Recipe newRecipe)             //zamienić na tą metode
        {                                                          //zamienić na tą metode
            newRecipe.Id = _recipe.Max(recipe => recipe.Id) + 1;   //zamienić na tą metode
            _recipe.Add(newRecipe);                                //zamienić na tą metode
                                                                   //zamienić na tą metode
            return newRecipe;                                      //zamienić na tą metode
        }
    }
}
