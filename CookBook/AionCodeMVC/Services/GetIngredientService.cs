using AionCodeMVC.Interfaces;
using AionCodeMVC.Models;
using Newtonsoft.Json;

namespace AionCodeMVC.Services
{
    public class GetIngredientService : IGetIngredientService
    {
        private IIngredientRepository _repository;
        public GetIngredientService(IIngredientRepository repository)
        {
            _repository = repository;
        }

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
