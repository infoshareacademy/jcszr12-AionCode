using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.Interfaces.IngredientInterfaces
{
    public interface IGetIngredientService
    {
        public IEnumerable<Ingredient> GetAll();
        public Ingredient GetByID(int id);
    }
}
