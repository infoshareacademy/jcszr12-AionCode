using CookBook.BuisnesLogic.DTO;

namespace CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces
{
    public interface IDeleteMyFridgeIngredientService
    {
        Task DeleteFridgeIngredient(MyFridgeIngredientDTO myFridgeIngredientDTO);
    }
}
