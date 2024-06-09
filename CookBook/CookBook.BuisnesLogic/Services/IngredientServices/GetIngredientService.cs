using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.AzureInterfaces;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using Database;
using Database.Entities;
using Database.EnumTypes;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;


namespace CookBook.BuisnesLogic.Services.IngredientServices
{
    public class GetIngredientService : IGetIngredientService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAzureStorage _azureStorage;

        public GetIngredientService(DatabaseContext dbContext, IMapper mapper, IAzureStorage azureStorage)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _azureStorage = azureStorage;
        }

        public async Task<IEnumerable<IngredientDTO>> GetIngredientDTOListAll()
        {
            List<IngredientDetails>? allIngredientsDetails = await _dbContext.IngredientDetails.OrderBy(ingredient => ingredient.Name).ToListAsync();
            var allIngredientsDetailsDTO = _mapper.Map<List<IngredientDTO>>(allIngredientsDetails);
            return allIngredientsDetailsDTO;
        }
        public async Task<IEnumerable<IngredientDTO>> GetIngredientDTOListContainString(string searchString)
        {
            List<IngredientDetails>? searchedIngredientsDetails = await _dbContext.IngredientDetails.Where(ingredient => ingredient.Name.Contains(searchString)).OrderBy(ingredient => ingredient.Name).ToListAsync();
            var searchedIngredientsDetailsDTO = _mapper.Map<List<IngredientDTO>>(searchedIngredientsDetails);
            return searchedIngredientsDetailsDTO;
        }

        public async Task<IEnumerable<IngredientDTO>> GetIngredientDTOListType(string type)
        {
            if (Enum.TryParse(type, out IngredientType typeEnum))
            {
                List<IngredientDetails>? searchedIngredientsDetails = await _dbContext.IngredientDetails.Where(ingredient => ingredient.Type == typeEnum).OrderBy(ingredient => ingredient.Name).ToListAsync();
                var searchedIngredientsDetailsDTO = _mapper.Map<List<IngredientDTO>>(searchedIngredientsDetails);
                return searchedIngredientsDetailsDTO;
            }
            return await GetIngredientDTOListAll();
        }
        public async Task<IngredientDetailedDTO> GetByNameIngredientDetailedDTO(string name)
        {
            IngredientDetails? ingredient = await _dbContext.IngredientDetails.FirstOrDefaultAsync(ingredient => ingredient.Name == name);
            IngredientDetailedDTO? ingredientDetailedDTO = _mapper.Map<IngredientDetailedDTO>(ingredient);

            ingredientDetailedDTO.ImagePath = $"{_azureStorage.BlobContainerClientIngredientFiles.Uri}/{ingredientDetailedDTO.ImagePath}";


            if (ingredient != null)
            {
                ingredientDetailedDTO.Comments = await GetCommentsForIngredient(ingredient.Id);
            }
            return ingredientDetailedDTO;
        }
        public async Task<IngredientDetailedDTO> GetByIdIngredientDetailedDTO(int id)
        {
            IngredientDetails? ingredient = await _dbContext.IngredientDetails.FirstOrDefaultAsync(ingredient => ingredient.Id == id);
            IngredientDetailedDTO? ingredientDetailedDTO = _mapper.Map<IngredientDetailedDTO>(ingredient);

            if (ingredientDetailedDTO.ImagePath == null)
            {
                ingredientDetailedDTO.ImagePath = "NoImage.png";
            }
            ingredientDetailedDTO.ImagePath = $"{_azureStorage.BlobContainerClientIngredientFiles.Uri}/{ingredientDetailedDTO.ImagePath}";

            if (ingredient!=null)
            {
                ingredientDetailedDTO.Comments = await GetCommentsForIngredient(ingredient.Id);
            }
            return ingredientDetailedDTO;
        }
        public async Task<IngredientEditDTO> GetByIdIngredientEditedDTO(int id)
        {
            var ingredient = await _dbContext.IngredientDetails.Where(ingredient => ingredient.Id == id).FirstOrDefaultAsync();
            var ingredientEditDTO = _mapper.Map<IngredientEditDTO>(ingredient);

            return ingredientEditDTO;
        }

        public async Task<IEnumerable<IngredientCommentDTO>> GetCommentsForIngredient(int ingredientId)
        {
            var ingredientComments = await _dbContext.IngredientComment
                                            .Where(comment => comment.IngredientDetailsId == ingredientId)
                                            .ToListAsync();

            var ingredientCommentsDTO = _mapper.Map<List<IngredientCommentDTO>>(ingredientComments);

            return ingredientCommentsDTO;
        }

        public async Task<List<IngredientDTO>> GetIngredientsByTerm(string term)
        {
            var lowerTerm = term.ToLower(); // Przekształć termin na małe litery

            var ingredients = await _dbContext.IngredientDetails
                .Where(i => i.Name.ToLower().Contains(lowerTerm))
                .Select(i => new IngredientDTO { Id = i.Id, Name = i.Name })
                .ToListAsync();

            return ingredients;
        }


    }
}
