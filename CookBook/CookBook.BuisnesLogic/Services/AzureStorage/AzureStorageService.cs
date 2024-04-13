using Azure.Storage.Blobs;
using CookBook.BuisnesLogic.Interfaces.AzureInterfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Services.AzureStorage
{
    public class AzureStorageService : IAzureStorage
    {
        public BlobContainerClient _blobContainerClientIngredientFiles { get; set; }

        public AzureStorageService(BlobServiceClient blobServiceClient)
        {
            _blobContainerClientIngredientFiles = blobServiceClient.GetBlobContainerClient("ingredient-files");
        }
    }
}
