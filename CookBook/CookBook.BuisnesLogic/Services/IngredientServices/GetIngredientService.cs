using AutoMapper;
using Azure.Storage.Blobs;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.AzureInterfaces;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Models;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
            List<IngredientDetails>? allIngredientsDetails = await _dbContext.IngredientDetails.ToListAsync();
            var allIngredientsDetailsDTO = _mapper.Map<List<IngredientDTO>>(allIngredientsDetails);
            return allIngredientsDetailsDTO;
        }

        public async Task<IngredientDetailedDTO> GetByNameIngredientDetailedDTO(string name)
        {
            IngredientDetails? ingredient = await _dbContext.IngredientDetails.Where(ingredient => ingredient.Name == name).FirstOrDefaultAsync();
            var ingredientDetailedDTO = _mapper.Map<IngredientDetailedDTO> (ingredient);

            ingredientDetailedDTO.ImagePath = $"{_azureStorage._blobContainerClientIngredientFiles.Uri.ToString()}/{ingredientDetailedDTO.ImagePath}";


            /* Usuwanie dziala z poziomu getingredient
            IngredientDetails? aa = await _dbContext.IngredientDetails.Where(ingredient => ingredient.Name == "TEst").FirstOrDefaultAsync();
            _dbContext.IngredientDetails.Remove(aa);
            _dbContext.SaveChanges();
            */

            return ingredientDetailedDTO;
        }

        public async Task<IngredientEditDTO> GetByIdIngredientEditedDTO (int id)
        {
            var ingredient = await _dbContext.IngredientDetails.Where(ingredient => ingredient.Id == id).FirstOrDefaultAsync();
            var ingredientEditDTO = _mapper.Map<IngredientEditDTO>(ingredient);

            return ingredientEditDTO;
        }
    }
}
