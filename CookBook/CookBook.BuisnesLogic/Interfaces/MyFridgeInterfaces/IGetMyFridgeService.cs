using CookBook.BuisnesLogic.DTO;

namespace CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces
{
    public interface IGetMyFridgeService
    {
        Task<IEnumerable<MyFridgeDTO>> GetAllMyFridges();
        //Task<IEnumerable<RecipeDTO>> GetProposedRecipes(IEnumerable<MyFridgeDTO>? myFridges);
        Task<List<Tuple<RecipeDTO, List<string>, List<string>>>> GetProposedRecipes(IEnumerable<MyFridgeDTO> myFridges);
    }
}
