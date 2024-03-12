using AionCodeMVC.Models;

namespace AionCodeMVC.Interfaces
{
    public interface IIngredientRepository
    {
        public IEnumerable<Ingredient> GetAll();
        public Ingredient GetByID(int id);
        public void CreateIngredient(Ingredient ingredient);
        public void DeleteIngredient(int id);

    }
}
