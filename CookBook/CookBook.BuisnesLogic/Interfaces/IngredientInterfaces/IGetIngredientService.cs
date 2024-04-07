using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.Interfaces.IngredientInterfaces
{
    public interface IGetIngredientService
    {
        public Task<IEnumerable<Ingredient>> GetAll();
        //public IEnumerable<Ingredient> GetAll();
        public Ingredient GetByID(int id);
    }
}
