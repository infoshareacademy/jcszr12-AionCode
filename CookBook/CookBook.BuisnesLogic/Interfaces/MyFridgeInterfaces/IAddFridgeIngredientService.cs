using CookBook.BuisnesLogic.DTO;

namespace CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces
{
    public interface IAddFridgeIngredientService
    {
        Task AddFridgeIngredient(MyFridgeIngredientDTO myFridgeIngredientDTO, string ingredientName);
    }
}
