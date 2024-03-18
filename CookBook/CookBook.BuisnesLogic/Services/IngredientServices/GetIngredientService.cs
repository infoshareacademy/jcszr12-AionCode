using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.Services.IngredientServices
{
    public class GetIngredientService(IIngredientRepository repository) : IGetIngredientService
    {
        private readonly IIngredientRepository _repository = repository;

        public IEnumerable<Ingredient> GetAll()
        {
            return _repository.GetAll();
        }

        public Ingredient GetByID(int id)
        {
            return _repository.GetByID(id);
        }
    }
}
