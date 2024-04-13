using Azure.Storage.Blobs;

namespace CookBook.BuisnesLogic.Interfaces.AzureInterfaces
{
    public interface IAzureStorage
    {
        public BlobContainerClient _blobContainerClientIngredientFiles { get; set; }
    }
}