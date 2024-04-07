using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using Microsoft.AspNetCore.Http;
using Azure.Storage.Blobs;

namespace CookBook.BuisnesLogic.Services.IngredientServices
{
    public class UploadIngredientPhotoService : IUploadIngredientPhotoService
    {
        private IIngredientRepository _repository;

        public UploadIngredientPhotoService(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public string AddPhoto(IFormFile file, int id)
        { 
            return _repository.AddPhoto(file, id);
        }


    }
}
