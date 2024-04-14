using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.Interfaces.IngredientInterfaces
{
    public interface IEditIngredientService
    {
        public Task Edit(IngredientEditDTO ingredientEdited);
    }
}
