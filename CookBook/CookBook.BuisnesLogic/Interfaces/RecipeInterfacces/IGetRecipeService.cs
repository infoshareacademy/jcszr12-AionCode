using CookBook.BuisnesLogic.DTO;

namespace CookBook.BuisnesLogic.Interfaces.RecipeInterfacces
{
    public interface IGetRecipeService
    {
        public Task<IEnumerable<RecipeDTO>> GetAllRecipeDTO();
        //public Task<RecipeDetailsDTO> GetRecipeByNameDTO(string name);
        //public Task<RecipeEditDTO> GetRecipeByEditedDTO(int id);
        public Task<RecipeDetailsDTO> GetRecipeByDetails(int id);
        //public Task<IEnumerable<RecipeDTO>> GetRecipeDTOByString(string search);

    }
}
