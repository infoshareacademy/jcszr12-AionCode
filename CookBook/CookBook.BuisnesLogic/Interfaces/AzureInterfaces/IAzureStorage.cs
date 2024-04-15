using Azure.Storage.Blobs;

namespace CookBook.BuisnesLogic.Interfaces.AzureInterfaces
{
    public interface IAzureStorage
    {
        public BlobContainerClient BlobContainerClientIngredientFiles { get; set; }
    }
}