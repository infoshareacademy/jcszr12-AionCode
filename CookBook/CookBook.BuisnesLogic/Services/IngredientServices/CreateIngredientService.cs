using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Models;
using Database;
using Database.Entities;
using Newtonsoft.Json;
using System.IO;

namespace CookBook.BuisnesLogic.Services.IngredientServices
{
    //TO DO
    public class CreateIngredientService : ICreateIngredientService
    {

        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public CreateIngredientService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateIngredient(IngredientDetailedDTO ingredient)
        {
            var ingredientToAdd = _mapper.Map<IngredientDetails>(ingredient);
            if (ingredientToAdd.ImagePath == null)
            {
                ingredientToAdd.ImagePath = "TEst.png";
            }
            
            ingredientToAdd.AddDate = DateTime.Now;
            await _dbContext.IngredientDetails.AddAsync(ingredientToAdd);
            _dbContext.SaveChanges();
        }
    }
}
