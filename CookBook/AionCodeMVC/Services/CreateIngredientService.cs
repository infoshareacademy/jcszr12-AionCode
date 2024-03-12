using AionCodeMVC.Interfaces;
using AionCodeMVC.Models;

namespace AionCodeMVC.Services
{
    public class CreateIngredientService : ICreateIngredientService
    {
        private IIngredientRepository _repository;
        public CreateIngredientService(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public void CreateIngredient(Ingredient ingredient)
        {
            _repository.CreateIngredient(ingredient);
        }
    }
}
