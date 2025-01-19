using Azure.Storage.Blobs;
using CookBook.BuisnesLogic.Interfaces.AzureInterfaces;

namespace CookBook.BuisnesLogic.Services.AzureStorage
{
    public class AzureStorageService : IAzureStorage
    {
        public BlobContainerClient BlobContainerClientIngredientFiles { get; set; }
        public BlobContainerClient BlobContainerClientRecipeFiles { get; set; }
        public AzureStorageService(BlobServiceClient blobServiceClient)
        {
            BlobContainerClientIngredientFiles = blobServiceClient.GetBlobContainerClient("ingredient-files");
            BlobContainerClientRecipeFiles = blobServiceClient.GetBlobContainerClient("book-files");
        }
    }
}
