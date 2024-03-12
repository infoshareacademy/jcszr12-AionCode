using AionCodeMVC.Models;

namespace AionCodeMVC.Interfaces
{
    public interface IIngredientService
    {
        public IEnumerable<Ingredient> GetAll();
    }
}
