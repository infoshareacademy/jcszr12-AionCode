using CookBook.BuisnesLogic.DTO;

namespace CookBook.BuisnesLogic.Interfaces.IngredientInterfaces
{
    public interface IEditIngredientService
    {
        public Task Edit(IngredientEditDTO ingredientEdited);
    }
}
