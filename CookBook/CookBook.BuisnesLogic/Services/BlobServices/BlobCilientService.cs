using Microsoft.AspNetCore.Http;
using Azure.Storage.Blobs;

namespace CookBook.BuisnesLogic.Services.BlobServices
{
    public interface IBlobClientService 
    {
        string AddPhoto(IFormFile file);
    }
    public class BlobCilientService : IBlobClientService
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
                    blobContainer.UploadBlob(file.FileName, stream);
                    return $"{blobContainer.Uri}/{file.FileName}";
                }
                catch (Exception ex)
                { 
                    throw new NotImplementedException(ex.Message);
                }

            }
                
        }
    }
}
