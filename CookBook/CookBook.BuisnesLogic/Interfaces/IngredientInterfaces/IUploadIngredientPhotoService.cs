using Microsoft.AspNetCore.Http;

namespace CookBook.BuisnesLogic.Interfaces.IngredientInterfaces
{
    public interface IUploadIngredientPhotoService
    {
        public string AddPhoto(IFormFile file);
    }
}
