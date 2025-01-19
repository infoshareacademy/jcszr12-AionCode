using CookBook.BuisnesLogic.DTO;

namespace CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces
{
    public interface IDeleteMyFridgeService
    {
        Task DeleteFridgeIngredient(MyFridgeIngredientDTO myFridgeIngredientDTO);
        Task DeleteFridge(int id);
    }
}
