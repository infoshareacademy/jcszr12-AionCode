using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Models;
namespace CookBook.BuisnesLogic.Interfaces.IngredientInterfaces
{
    public interface ICreateIngredientService
    {
        public Task CreateIngredient(IngredientDetailedDTO ingredient);
    }
}
