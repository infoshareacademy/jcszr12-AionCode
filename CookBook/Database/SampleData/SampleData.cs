using Database.Entities;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Database.SampleData
{
    public static class SampleData
    {
        public static List<IngredientDetails> GetIngredientDetailsSampleDataFromJson()
        {

            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // Połącz ścieżkę katalogu z nazwą pliku
            string filePath = Path.Combine(basePath, "IngredientDetailsSeed-data.json");

            // Odczytaj zawartość pliku
            string seedData = File.ReadAllText(filePath);

            var result = JsonConvert.DeserializeObject<List<IngredientDetails>>(seedData);

            return result;

            // Seed data from JSON file
        }
        public static async Task<string> GetAdminUserIdAsync(UserManager<IdentityUser> userManager)
        {
            var user = await userManager.FindByNameAsync("admin");

            if (user != null)
            {
                return user.Id;
            }
            else
            {
                return null;
            }
        }
        public static List<UserCookBook> GetUserCookBookSampleDataFromJson()
        {

            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // Połącz ścieżkę katalogu z nazwą pliku
            string filePath = Path.Combine(basePath, "UserCookBookSeed-data.json");

            // Odczytaj zawartość pliku
            string seedData = File.ReadAllText(filePath);


            return JsonConvert.DeserializeObject<List<UserCookBook>>(seedData);

            // Seed data from JSON file
        }
        public static List<RecipeDetails> GetRecipeDetailsSampleDataFromJson()
        {

            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // Połącz ścieżkę katalogu z nazwą pliku
            string filePath = Path.Combine(basePath, "RecipeDetailsSeed-data.json");

            // Odczytaj zawartość pliku
            string seedData = File.ReadAllText(filePath);


            return JsonConvert.DeserializeObject<List<RecipeDetails>>(seedData);

            // Seed data from JSON file
        }
    }
}
