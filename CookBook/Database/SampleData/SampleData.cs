using Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Database.SampleData
{
    public static class SampleData
    {
        static readonly Random random = new();

        #region IngredientDataSample
        public static async Task SeedDatabaseWithIngredients(DatabaseContext dbContext, IQueryable<UserCookBook> users)
        {
            if (!dbContext.IngredientDetails.Any())
            {
                var ingredientDetailsList = GetIngredientDetailsSampleDataFromJson();
                var userIds = await users.Select(u => u.Id).ToListAsync();

                AssingIngredientsToUsersRandomly(ingredientDetailsList, userIds);

                if (ingredientDetailsList != null)
                {
                    dbContext.IngredientDetails.AddRange(ingredientDetailsList);
                }

                await dbContext.SaveChangesAsync();
            }
        }

        private static List<IngredientDetails>? GetIngredientDetailsSampleDataFromJson()
        {

            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // Połącz ścieżkę katalogu z nazwą pliku
            string filePath = Path.Combine(basePath, "IngredientDetailsSeed-data.json");

            // Odczytaj zawartość pliku
            string seedData = File.ReadAllText(filePath);

            var result = JsonConvert.DeserializeObject<List<IngredientDetails>>(seedData);

            return result;
        }
        private static void AssingIngredientsToUsersRandomly(List<IngredientDetails>? ingredientDetailsList, List<string> userIds)
        {
            if (ingredientDetailsList != null)
            {
                foreach (var ingredient in ingredientDetailsList)
                {
                    var randomUserIdIndex = random.Next(0, userIds.Count);
                    ingredient.UserCookBookId = userIds[randomUserIdIndex];
                }
            }
        }

        #endregion IngredientDataSample


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


        public static async Task SeedDatabaseWithRecipes(DatabaseContext dbContext, IQueryable<UserCookBook> users)
        {
            if (!dbContext.RecipeDetails.Any())
            {
                var recipeDetailsList = GetRecipeDetailsSampleDataFromJson();
                var userIds = await users.Select(u => u.Id).ToListAsync();

                AssingRecipesToUsersRandomly(recipeDetailsList, userIds);

                if (recipeDetailsList != null)
                {
                    dbContext.RecipeDetails.AddRange(recipeDetailsList);
                }
                await dbContext.SaveChangesAsync();
            }
        }

        private static void AssingRecipesToUsersRandomly(List<RecipeDetails> recipeDetailsList, List<string> userIds)
        {
            if (recipeDetailsList != null)
            {
                foreach (var recipe in recipeDetailsList)
                {
                    var randomUserIdIndex = random.Next(0, userIds.Count);
                    recipe.UserCookBookId = userIds[randomUserIdIndex];
                }
            }
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
