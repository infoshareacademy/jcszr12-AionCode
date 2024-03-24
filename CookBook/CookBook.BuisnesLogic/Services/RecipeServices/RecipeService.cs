using Azure.Storage.Blobs;
using CookBook.BuisnesLogic.Interfaces.RecipeInterfaces;
using CookBook.BuisnesLogic.Models;
using CookBook.BuisnesLogic.Repositories.RecipeRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Azure;
using System.Reflection;

namespace CookBook.BuisnesLogic.Services.RecipeServices
{
    public class RecipeService : IRecipeRepository
    {
        private readonly IList<Recipe> _recipe = LoadRecipe.ReadRecipeFromJson();       

        public IEnumerable<Recipe> GetAll()
        {
            return _recipe;
        }

        public Recipe GetById(int id)
        {
            return _recipe.FirstOrDefault(x => x.Id == id);
        }

        public void CreateRecipe(int id, Recipe recipe, IFormFile file)
        {
            recipe.Id = _recipe.Max(x => x.Id) + 1;


            recipe.imageURL = $"http://127.0.0.1:10000/devstoreaccount1/book-files/{recipe.imageURL}";

            

           _recipe.Add(recipe);

            SaveRecipe.SaveRecipeToJson(recipe);
        }
        public void DeleteRecipe(int id)
        {
            var recipeList = _recipe;
            var recipeToRemove = GetById(id);
            if (recipeToRemove != null) 
            {
                recipeList.Remove(recipeToRemove);
                SaveRecipe.SaveRecipeToJson((Recipe)recipeList);
            }
        }
        public void UpdateRecipe(int id, Recipe recipe)
        {           
            var recipeToUpdate = GetById(id);
            if (recipeToUpdate != null)
            {
                recipeToUpdate.Id = recipe.Id;
                recipeToUpdate.Name = recipe.Name;
                recipeToUpdate.Category = recipe.Category;
                recipeToUpdate.Description = recipe.Description;
                recipeToUpdate.IngredientList = recipe.IngredientList;     

                SaveRecipe.SaveRecipeToJson(recipe);
            }            
        }        
    }
}
