using Microsoft.AspNetCore.Http;

namespace CookBook.BuisnesLogic.Interfaces.RecipeInterfacces
{
    public interface IUploadRecipePhotoService
    {
        public Task AddRecipePhoto(IFormFile file, int id);
    }
}
