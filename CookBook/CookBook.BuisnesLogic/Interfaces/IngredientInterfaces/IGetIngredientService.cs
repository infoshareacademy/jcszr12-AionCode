using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.Interfaces.IngredientInterfaces
{
    public interface IGetIngredientService
    {
        public Task<IEnumerable<IngredientDTO>> GetIngredientDTOListAll();
        public Task<IngredientDetailedDTO> GetByNameIngredientDetailedDTO(string name);
    }
}
