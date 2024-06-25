using CookBook.BuisnesLogic.DTO;

namespace CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces
{
    public interface IGetMyFridgeService
    {
        Task<IEnumerable<MyFridgeDTO>> GetAllMyFridges();
    }
}
