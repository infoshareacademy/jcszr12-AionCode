using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.RecipeInterfacces;
using Database;
using Database.Entities;

namespace CookBook.BuisnesLogic.Services.IngredientServices
{
    public class CreateRecipeService : ICreateRecipeService
    {

        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public CreateRecipeService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateRecipe(RecipeDetailsDTO recipe)
        {
            var recipeToAdd = _mapper.Map<RecipeDetails>(recipe);

            recipeToAdd.UserCookBookId = "abecadlo";
            recipeToAdd.AddDate = DateTime.Now;

            await _dbContext.RecipeDetails.AddAsync(recipeToAdd);
            _dbContext.SaveChanges();
        }
    }
}
