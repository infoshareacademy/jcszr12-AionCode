using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.Services.IngredientServices
{
    public class DeleteIngredientService : IDeleteIngredientService
    {
        private IIngredientRepository _repository;
        public DeleteIngredientService(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public void DeleteIngredient(int id)
        {
            _repository.DeleteIngredient(id);
        }
    }
}
