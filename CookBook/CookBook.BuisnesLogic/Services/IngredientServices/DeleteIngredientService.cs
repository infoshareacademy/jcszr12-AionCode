using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.AzureInterfaces;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Models;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;

namespace CookBook.BuisnesLogic.Services.IngredientServices
{

    public class DeleteIngredientService : IDeleteIngredientService
    {
        private DatabaseContext _dbContext;
        private readonly IAzureStorage _azureStorage;
        public DeleteIngredientService(DatabaseContext dbContext, IAzureStorage azureStorage)
        {
            _dbContext = dbContext;
            _azureStorage = azureStorage;
        }

        public async Task DeleteIngredient(int id)
        {
            IngredientDetails? ingredient = await _dbContext.IngredientDetails.Where(ingredient => ingredient.Id == id).FirstOrDefaultAsync();

            if (ingredient != null) 
            {
                var connectedRecipes = await _dbContext.IngredientUsed.AnyAsync(i => i.IngredientDetailsId == ingredient.Id);
                if (connectedRecipes == false)
                {
                    _dbContext.IngredientDetails.Remove(ingredient);
                    if (ingredient.ImagePath != null)
                    {
                        await _azureStorage.BlobContainerClientIngredientFiles.DeleteBlobIfExistsAsync(ingredient.ImagePath, Azure.Storage.Blobs.Models.DeleteSnapshotsOption.IncludeSnapshots);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
