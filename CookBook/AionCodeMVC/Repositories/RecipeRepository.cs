using CookBook.BuisnesLogic.Interfaces.RecipeInterfaces;
using CookBook.BuisnesLogic.Models;
using Newtonsoft.Json;

namespace AionCodeMVC.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private static string path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "dataRecipes.json");
        public IEnumerable<Recipe> GetAll() 
        {
            return ReadRecipeFromJson();
        }
        public List<Recipe> ReadRecipeFromJson()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }              
            var recipeAllSerialize = File.ReadAllText(path);
            var recipeList = JsonConvert.DeserializeObject<List<Recipe>>(recipeAllSerialize);

            if (recipeList == null)
            {
                recipeList = new List<Recipe>();
            }
            return recipeList;            
        }
        public void CreateRecipe(Recipe recipe)
        {
            var recipes = GetAll().ToList();
            if (!recipes.Any(x => x.Id == recipe.Id))
            {
                var number = recipes.Max(x => x.Id);
                recipe.Id = number + 1;
                recipes.Add(recipe);
            }
            var json = JsonConvert.SerializeObject(recipes, Formatting.Indented);
            File.WriteAllText(path, json);
        }
        public void DeleteRecipe(int id)
        {
            var recipes = GetAll().ToList();
            var recipeToDelete = recipes.FirstOrDefault(x => x.Id == id);
            if (recipeToDelete != null) 
            {
                recipes.Remove(recipeToDelete);
            }
            var json = JsonConvert.SerializeObject(recipes, Formatting.Indented);
            File.WriteAllText(path, json);
        }
        public void EditRecipe(Recipe recipe)
        {
            var recipes = GetAll().ToList();
            var recipeToUpdate = recipes.FirstOrDefault(x => x.Id == recipe.Id);

            if (recipeToUpdate != null)
            { 
                recipeToUpdate.Name = recipe.Name;
                recipeToUpdate.Category = recipe.Category;
                recipeToUpdate.Description = recipe.Description;
                recipeToUpdate.IngredientList = recipe.IngredientList;

                var json = JsonConvert.SerializeObject(recipes, Formatting.Indented);
                File.WriteAllText(path, json);
            }
        }
        public Recipe GetById(int id)
        {
            return ReadRecipeFromJson().FirstOrDefault(x => x.Id == id);
        }
    }
}
