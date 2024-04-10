using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.Services.IngredientServices
{
    //TO DO
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
