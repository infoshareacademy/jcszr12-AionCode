using CookBook.BuisnesLogic.Interfaces.AzureInterfaces;
using CookBook.BuisnesLogic.Interfaces.RecipeInterfacces;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BuisnesLogic.Services.RecipeServices
{

    public class DeleteRecipeService : IDeleteRecipeService
    {
        private DatabaseContext _dbContext;
        private readonly IAzureStorage _azureStorage;
        public DeleteRecipeService(DatabaseContext dbContext, IAzureStorage azureStorage)
        {
            _dbContext = dbContext;
            _azureStorage = azureStorage;
        }

        public async Task DeleteRecipe(int id)
        {
            RecipeDetails? recipe = await _dbContext.RecipeDetails.Where(recipe => recipe.Id == id).FirstOrDefaultAsync();
            if (recipe != null)
            {
                _dbContext.RecipeDetails.Remove(recipe);
                if (recipe.ImagePath == null || recipe.ImagePath == $"{_azureStorage.BlobContainerClientRecipeFiles.Uri}/null.jpg")
                {
                    _dbContext.SaveChanges();
                    return;
                }
                else 
                {
                    await _azureStorage.BlobContainerClientRecipeFiles.DeleteBlobIfExistsAsync(recipe.ImagePath, Azure.Storage.Blobs.Models.DeleteSnapshotsOption.IncludeSnapshots);
                }
            }
            _dbContext.SaveChanges();
        }
    }
}
