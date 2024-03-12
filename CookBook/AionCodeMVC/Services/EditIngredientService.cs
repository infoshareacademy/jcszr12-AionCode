using AionCodeMVC.Interfaces;
using AionCodeMVC.Models;

namespace AionCodeMVC.Services
{
    public class EditIngredientService : IEditIngredientService
    {
        private IIngredientRepository _repository;
        public EditIngredientService(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public void Edit(Ingredient ingredient)
        {
            _repository.Edit(ingredient);
        }
    }
}
