using CookBook.BuisnesLogic.Interfaces.AzureInterfaces;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using Database;
using Microsoft.AspNetCore.Http;

namespace CookBook.BuisnesLogic.Services.IngredientServices
{
    public class UploadIngredientPhotoService : IUploadIngredientPhotoService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IAzureStorage _azureStorage;

        public UploadIngredientPhotoService(DatabaseContext dbContext, IAzureStorage azureStorage)
        {
            _dbContext = dbContext;
            _azureStorage = azureStorage;
        }

        public async Task AddPhoto(IFormFile file, int id)
        {
            var fileName = $"{file.FileName}";

            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                stream.Position = 0;

                try
                {
                    _azureStorage.BlobContainerClientIngredientFiles.UploadBlob(fileName, stream);
                }
                catch (Azure.RequestFailedException e)
                {
                    if (e.ErrorCode == "BlobAlreadyExists")
                    {
                        stream.Position = 0;
                        fileName = $"{DateTime.Now.Millisecond}-{file.FileName}";
                        _azureStorage.BlobContainerClientIngredientFiles.UploadBlob(fileName, stream);
                    }
                }

                var ingredientToUploadImg = _dbContext.IngredientDetails.FirstOrDefault(x => x.Id == id);

                if (ingredientToUploadImg != null)
                {
                    _dbContext.IngredientDetails.Entry(ingredientToUploadImg).Entity.ImagePath = fileName;
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
