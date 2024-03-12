using AionCodeMVC.Interfaces;

namespace AionCodeMVC.Services
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
