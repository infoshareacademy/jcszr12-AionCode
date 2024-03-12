using AionCodeMVC.Interfaces;
using AionCodeMVC.Models;
using Newtonsoft.Json;

namespace AionCodeMVC.Services
{
    public class IngredientService : IIngredientService
    {
        private IIngredientRepository _repository;
        public IngredientService(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
