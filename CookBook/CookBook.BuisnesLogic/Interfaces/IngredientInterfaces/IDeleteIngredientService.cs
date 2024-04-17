
using CookBook.BuisnesLogic.Interfaces.AzureInterfaces;

namespace CookBook.BuisnesLogic.Interfaces.IngredientInterfaces
{
    public interface IDeleteIngredientService
    {
        public Task DeleteIngredient(int id);
    }
}
