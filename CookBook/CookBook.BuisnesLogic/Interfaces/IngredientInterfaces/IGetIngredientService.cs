using CookBook.BuisnesLogic.DTO;

namespace CookBook.BuisnesLogic.Interfaces.IngredientInterfaces
{
    public interface IGetIngredientService
    {
        public Task<IEnumerable<IngredientDTO>> GetIngredientDTOListAll();

        public Task<IngredientDetailedDTO> GetByNameIngredientDetailedDTO(string name);

        public Task<IngredientEditDTO> GetByIdIngredientEditedDTO(int id);

        public Task<IngredientDetailedDTO> GetByIdIngredientDetailedDTO(int id);
        public Task<IEnumerable<IngredientDTO>> GetIngredientDTOListContainString(string searchString);
        public Task<IEnumerable<IngredientDTO>> GetIngredientDTOListType(string type);
    }
}
