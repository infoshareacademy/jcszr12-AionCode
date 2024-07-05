using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.AzureInterfaces;
using CookBook.BuisnesLogic.Interfaces.RecipeInterfacces;
using CookBook.BuisnesLogic.Models;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BuisnesLogic.Services.RecipeServices
{
    public class GetRecipeService : IGetRecipeService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAzureStorage _azureStorage;

        public GetRecipeService(DatabaseContext dbContext, IMapper mapper, IAzureStorage azureStorage)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _azureStorage = azureStorage;
        }

        public async Task<IEnumerable<RecipeDTO>> GetAllRecipeDTO()
        {
            List<RecipeDetails>? allRecipeDetails = await _dbContext.RecipeDetails.OrderBy(recipe => recipe.Id).ToListAsync();
            var allRecipeDetailsDTO = _mapper.Map<List<RecipeDTO>>(allRecipeDetails);
            return allRecipeDetailsDTO;
        }
        public async Task<RecipeDetailsDTO> GetRecipeByDetails(int id)
        {
            RecipeDetails? recipe = await _dbContext.RecipeDetails.FirstOrDefaultAsync(recipe => recipe.Id == id);
            RecipeDetailsDTO? recipeDetailsDTO = _mapper.Map<RecipeDetailsDTO>(recipe);

            if (recipeDetailsDTO.ImagePath == null)
            {
                recipeDetailsDTO.ImagePath = "NoImage.png";
            }
            recipeDetailsDTO.ImagePath = $"{_azureStorage.BlobContainerClientIngredientFiles.Uri}/{recipeDetailsDTO.ImagePath}";

            if (recipe != null)
            {
                recipeDetailsDTO.Comments = await GetCommentsForRecipe(recipe.Id);
            }

            return recipeDetailsDTO;
        }


        public async Task<IEnumerable<RecipeCommentDTO>> GetCommentsForRecipe(int recipeId)
        {
            var recipeComments = await _dbContext.RecipeComments
                                            .Where(comment => comment.RecipeDetailsId == recipeId)
                                            .ToListAsync();

            var recipeCommentsDTO = _mapper.Map<List<RecipeCommentDTO>>(recipeComments);

            return recipeCommentsDTO;
        }


    }
}
