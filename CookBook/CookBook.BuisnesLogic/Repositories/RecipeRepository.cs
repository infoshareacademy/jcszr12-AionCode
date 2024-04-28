using Azure.Storage.Blobs;
using CookBook.BuisnesLogic.Interfaces.RecipeInterfacces;
using CookBook.BuisnesLogic.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CookBook.BuisnesLogic.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private static string path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "recipe.json");
        public IEnumerable<Recipe> GetAll()
        {
            return ReadRecipeFromJson();
        }
        public Recipe GetByID(int id)
        {
            return ReadRecipeFromJson().FirstOrDefault(x => x.Id == id);
        }
        private static List<Recipe> ReadRecipeFromJson()
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
            if (!recipes.Any(i => i.Name == recipe.Name || i.Id == recipe.Id))
            {
                recipe.Id = recipes.Count() + 1;
                recipes.Add(recipe);
            }
            var json = JsonConvert.SerializeObject(recipes);
            File.WriteAllText(path, json);
        }

        public void DeleteRecipe(int id)
        {
            var recipes = GetAll().ToList();
            var recipeToDelete = recipes.FirstOrDefault(r => r.Id == id);
            if (recipeToDelete != null)
            {
                recipes.Remove(recipeToDelete);
            }
            var json = JsonConvert.SerializeObject(recipes);
            File.WriteAllText(path, json);

        }

        public void Edit(Recipe recipe)
        {
            var recipes = GetAll().ToList();
            var recipeToEdit = recipes.FirstOrDefault(r => r.Id == recipe.Id);

            if (recipeToEdit != null)
            {
                recipeToEdit.Name = recipe.Name;
                recipeToEdit.Category = recipe.Category;
                recipeToEdit.Description = recipe.Description;
                
            }

            var json = JsonConvert.SerializeObject(recipes);
            File.WriteAllText(path, json);

        }

        public string AddPhoto(IFormFile file, int id)
        {
            var uploadPhotoServiceClient = new BlobServiceClient("UseDevelopmentStorage=true");
            var recipePhotosContainer = uploadPhotoServiceClient.GetBlobContainerClient("recipe-photos");

            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                stream.Position = 0;
                recipePhotosContainer.UploadBlob(file.FileName, stream);

                var recipes = GetAll().ToList();
                var recipeToEdit = recipes.FirstOrDefault(r => r.Id == id);

                string photoUrl = $"{recipePhotosContainer.Uri}/{file.FileName}";

                recipeToEdit.ImagePath = photoUrl;

                var json = JsonConvert.SerializeObject(recipes);
                File.WriteAllText(path, json);

                return photoUrl;
            }
        }



    }
}
