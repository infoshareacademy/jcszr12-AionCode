using CookBook.BuisnesLogic.Models;
using Microsoft.AspNetCore.Http;
namespace CookBook.BuisnesLogic.Interfaces.IngredientInterfaces
{
    public interface IIngredientRepository
    {
        public IEnumerable<Ingredient> GetAll();
        public Ingredient GetByID(int id);
        public void CreateIngredient(Ingredient ingredient);
        public void DeleteIngredient(int id);
        public void Edit(Ingredient ingredient);
        public string AddPhoto(IFormFile file);

    }
}
