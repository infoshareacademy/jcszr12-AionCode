using Microsoft.AspNetCore.Http;

namespace CookBook.BuisnesLogic.Interfaces.IngredientInterfaces
{
    public interface IUploadIngredientPhotoService
    {
        public Task AddPhoto(IFormFile file, int id);
    }
}
