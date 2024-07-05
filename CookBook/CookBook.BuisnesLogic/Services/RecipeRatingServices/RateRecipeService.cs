using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.RecipeInterfacces;
using Database.Entities;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Services.RecipeRatingServices
{
    public class RateRecipeService : IRateRecipeService
    {

        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public RateRecipeService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task RateRecipe(RecipeRatingDTO recipeRatingDTO)
        {
            var recipeRating = _mapper.Map<RecipeRating>(recipeRatingDTO);
            _dbContext.RecipeRatings.Add(recipeRating);
            await _dbContext.SaveChangesAsync();
        }
    }
}
