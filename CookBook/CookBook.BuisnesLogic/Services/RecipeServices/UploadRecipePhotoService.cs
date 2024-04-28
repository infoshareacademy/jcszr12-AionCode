using AutoMapper;
using CookBook.BuisnesLogic.Interfaces.AzureInterfaces;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Interfaces.RecipeInterfacces;
using Database;
using Microsoft.AspNetCore.Http;

namespace CookBook.BuisnesLogic.Services.IngredientServices
{
    public class UploadRecipePhotoService : IUploadRecipePhotoService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IAzureStorage _azureStorage;

        public UploadRecipePhotoService(DatabaseContext dbContext, IAzureStorage azureStorage)
        {
            _dbContext = dbContext;
            _azureStorage = azureStorage;
        }

        public async Task AddRecipePhoto(IFormFile file, int id)
        {
            var fileName = $"{file.FileName}";

            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                stream.Position = 0;

                try
                {
                    _azureStorage.BlobContainerClientRecipeFiles.UploadBlob(fileName, stream);
                }
                catch (Azure.RequestFailedException e)
                {
                    if (e.ErrorCode == "BlobAlreadyExists")
                    {
                        stream.Position = 0;
                        fileName = $"{DateTime.Now.Millisecond}-{file.FileName}";
                        _azureStorage.BlobContainerClientRecipeFiles.UploadBlob(fileName, stream);
                    }
                }

                var recipeToUploadImg = _dbContext.RecipeDetails.FirstOrDefault(x => x.Id == id);

                if (recipeToUploadImg != null)
                {
                    _dbContext.RecipeDetails.Entry(recipeToUploadImg).Entity.ImagePath = fileName;
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
