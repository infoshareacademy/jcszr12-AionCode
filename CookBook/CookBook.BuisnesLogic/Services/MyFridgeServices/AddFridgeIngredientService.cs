using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using Database;
using Database.Entities;

namespace CookBook.BuisnesLogic.Services.MyFridgeServices
{
    public class AddFridgeIngredientService : IAddFridgeIngredientService
    {

        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IGetUserService _getUserService;

        public AddFridgeIngredientService(DatabaseContext dbContext, IMapper mapper, IGetUserService getUserService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _getUserService = getUserService;
        }

        public async Task AddFridgeIngredien(MyFridgeIngredientDTO myFridgeIngredientDTO, string ingredientName)
        {
            var userId = await _getUserService.LoggedUserIdAsync();

            if (userId != null && myFridgeIngredientDTO != null)
            {
                var myFridgeIngredient = _mapper.Map<MyFridgeIngredient>(myFridgeIngredientDTO);
                myFridgeIngredient.IngredientDetailsId = _dbContext.IngredientDetails.FirstOrDefault(i => i.Name == ingredientName).Id;
                myFridgeIngredient.AddDate = DateTime.Now;
                _dbContext.MyFridgeIngredient.Add(myFridgeIngredient);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
