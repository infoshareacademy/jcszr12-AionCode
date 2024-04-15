﻿using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.AzureInterfaces;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

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
            IngredientDetails? ingredient = await _dbContext.IngredientDetails.FirstOrDefaultAsync(ingredient => ingredient.Name == name);
            IngredientDetailedDTO? ingredientDetailedDTO = _mapper.Map<IngredientDetailedDTO>(ingredient);

            ingredientDetailedDTO.ImagePath = $"{_azureStorage.BlobContainerClientIngredientFiles.Uri}/{ingredientDetailedDTO.ImagePath}";

            return ingredientDetailedDTO;
        }
        public async Task<IngredientDetailedDTO> GetByIdIngredientDetailedDTO(int id)
        {
            IngredientDetails? ingredient = await _dbContext.IngredientDetails.FirstOrDefaultAsync(ingredient => ingredient.Id == id);
            IngredientDetailedDTO? ingredientDetailedDTO = _mapper.Map<IngredientDetailedDTO>(ingredient);

            ingredientDetailedDTO.ImagePath = $"{_azureStorage.BlobContainerClientIngredientFiles.Uri}/{ingredientDetailedDTO.ImagePath}";

            return ingredientDetailedDTO;
        }




        public async Task<IngredientEditDTO> GetByIdIngredientEditedDTO(int id)
        {
            var ingredient = await _dbContext.IngredientDetails.Where(ingredient => ingredient.Id == id).FirstOrDefaultAsync();
            var ingredientEditDTO = _mapper.Map<IngredientEditDTO>(ingredient);

            return ingredientEditDTO;
        }
    }
}
