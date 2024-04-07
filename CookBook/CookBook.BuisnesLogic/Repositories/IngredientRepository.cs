using Newtonsoft.Json;
using System.IO;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Models;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;

namespace CookBook.BuisnesLogic.Repositories
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

        public string AddPhoto(IFormFile file, int id)
        {
            var uploadPhotoServiceClient = new BlobServiceClient("UseDevelopmentStorage=true");
            var ingredientPhotosContainer = uploadPhotoServiceClient.GetBlobContainerClient("ingredient-photos");

            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                stream.Position = 0;
                ingredientPhotosContainer.UploadBlob(file.FileName, stream);

                var ingredients = GetAll().ToList();
                var ingredientToEdit = ingredients.FirstOrDefault(r => r.Id == id);

                string photoUrl = $"{ingredientPhotosContainer.Uri}/{file.FileName}";

                ingredientToEdit.PhotoUrl =photoUrl;

                var json = JsonConvert.SerializeObject(ingredients);
                File.WriteAllText(path, json);

                return photoUrl;
            }
        }



    }
}
