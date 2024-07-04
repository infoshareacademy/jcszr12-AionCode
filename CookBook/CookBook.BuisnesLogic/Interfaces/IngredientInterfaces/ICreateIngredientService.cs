using CookBook.BuisnesLogic.DTO;
namespace CookBook.BuisnesLogic.Interfaces.IngredientInterfaces
{
    public interface ICreateIngredientService
    {
        public Task CreateIngredient(IngredientDetailedDTO ingredient);
    }
}
