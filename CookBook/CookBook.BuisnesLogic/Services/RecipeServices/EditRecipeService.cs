using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.RecipeInterfacces;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;


namespace CookBook.BuisnesLogic.Services.IngredientServices
{
    public class EditRecipeService : IEditRecipeService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public EditRecipeService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task EditRecipe(RecipeEditDTO recipeEdit)
        {
            var recipeEditedMapped = _mapper
                        .Map<RecipeDetails>(recipeEdit);

            var recipeInDatabase = await _dbContext.RecipeDetails
                        .Where(x => x.Id == recipeEdit.Id)
                        .FirstOrDefaultAsync();

            if (recipeInDatabase != null)
            {
                _dbContext.RecipeDetails
                         .Entry(recipeInDatabase)
                         .CurrentValues
                         .SetValues(recipeEditedMapped);
                _dbContext.SaveChanges();
            }
        }

    }
}
