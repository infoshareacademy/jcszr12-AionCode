using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Models;
using Database;
using Database.Entities;
using Newtonsoft.Json;
using System.IO;
using CookBook.BuisnesLogic.Services.UserServices;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;

namespace CookBook.BuisnesLogic.Services.IngredientServices
{
    //TO DO
    public class CreateIngredientService : ICreateIngredientService
    {

        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IGetUserService _getUserService;

        public CreateIngredientService(DatabaseContext dbContext, IMapper mapper, IGetUserService userService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _getUserService = userService;
        }

        public async Task CreateIngredient(IngredientDetailedDTO ingredient)
        {
            var ingredientToAdd = _mapper.Map<IngredientDetails>(ingredient);

            ingredientToAdd.UserCookBookId = await _getUserService.LoggedUserIdAsync();
            ingredientToAdd.AddDate = DateTime.Now;

            await _dbContext.IngredientDetails.AddAsync(ingredientToAdd);
            _dbContext.SaveChanges();
        }
    }
}
