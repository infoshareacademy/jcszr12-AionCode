using CookBook.BuisnesLogic.DTO;

namespace CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces
{
    public interface ICreateFridgeService
    {
        Task AddFridge(MyFridgeDTO fridgeDTO);
    }
}
