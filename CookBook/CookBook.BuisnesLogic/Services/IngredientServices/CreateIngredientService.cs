using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.Services.IngredientServices
{
    //TO DO
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
