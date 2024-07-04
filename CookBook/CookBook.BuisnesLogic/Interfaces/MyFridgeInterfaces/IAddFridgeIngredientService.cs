using CookBook.BuisnesLogic.DTO;

namespace CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces
{
    public interface IAddFridgeIngredientService
    {
        Task AddFridgeIngredien(MyFridgeIngredientDTO myFridgeIngredientDTO, string ingredientName);
    }
}
