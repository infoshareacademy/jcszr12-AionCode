using Azure.Storage.Blobs;
using CookBook.BuisnesLogic.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace CookBook.BuisnesLogic.Interfaces.RecipeInterfaces
{
    public interface IBlobClientService
    {
        public string AddPhoto(IFormFile file);
    }
    public class BlobClientService : IBlobClientService

    {
        public string AddPhoto(IFormFile file)
        {
            var blobServiceCilent = new BlobServiceClient("UseDevelopmentStorage=true");
            var blobContainer = blobServiceCilent.GetBlobContainerClient("book-files");
            using (var stream = new MemoryStream())
            {
                try
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    blobContainer.UploadBlob(file.Name, stream);
                    return $"{blobContainer.Uri}/{file.Name}";

                }
                catch (Exception ex)
                {
                    throw new NotImplementedException(ex.Message);
                }
            }
        }

    }
}
