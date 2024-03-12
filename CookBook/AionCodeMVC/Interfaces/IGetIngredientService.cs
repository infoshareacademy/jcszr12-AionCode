using AionCodeMVC.Models;

namespace AionCodeMVC.Interfaces
{
    public interface IGetIngredientService
    {
        public IEnumerable<Ingredient> GetAll();
        public Ingredient GetByID(int id);
    }
}
