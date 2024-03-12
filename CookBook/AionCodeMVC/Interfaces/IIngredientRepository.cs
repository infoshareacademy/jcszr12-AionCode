using AionCodeMVC.Models;

namespace AionCodeMVC.Interfaces
{
    public interface IIngredientRepository
    {
        public IEnumerable<Ingredient> GetAll();
    }
}
