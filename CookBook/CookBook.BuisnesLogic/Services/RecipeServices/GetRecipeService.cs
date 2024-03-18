using CookBook.BuisnesLogic.Interfaces.RecipeInterfaces;
using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.Services.RecipeServices
{
    public class GetRecipeService(IRecipeRepository repository) : IGetRecipeService
    {    
        private readonly IRecipeRepository _repository = repository;

        public IEnumerable<Recipe> GetAllRecipe()
        {
            return _repository.GetAll();
        }

        public Recipe GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}
