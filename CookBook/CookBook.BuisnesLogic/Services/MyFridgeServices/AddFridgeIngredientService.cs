using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;


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

        public async Task AddFridgeIngredient(MyFridgeIngredientDTO myFridgeIngredientDTO, string ingredientName)
        {
            var userId = await _getUserService.LoggedUserIdAsync();

            if (userId != null && myFridgeIngredientDTO != null)
            {
                // Sprawdź, czy składnik już istnieje w lodówce użytkownika
                var existingFridgeIngredient = await _dbContext.MyFridgeIngredient
                    .FirstOrDefaultAsync(f => f.MyFridge.UserCookBookId == userId && f.IngredientDetails.Name == ingredientName);

                if (existingFridgeIngredient == null)
                {
                    var myFridgeIngredient = _mapper.Map<MyFridgeIngredient>(myFridgeIngredientDTO);
                    var ingredientDetails = _dbContext.IngredientDetails.FirstOrDefault(i => i.Name == ingredientName);
                    if (ingredientDetails != null)
                    {
                        myFridgeIngredient.IngredientDetailsId = ingredientDetails.Id;
                        myFridgeIngredient.AddDate = DateTime.Now;

                        // Pobierz lub utwórz nową lodówkę dla użytkownika
                        var myFridge = await _dbContext.MyFridge.FirstOrDefaultAsync(f => f.UserCookBookId == userId);
                        if (myFridge == null)
                        {
                            myFridge = new MyFridge { UserCookBookId = userId };
                            _dbContext.MyFridge.Add(myFridge);
                            await _dbContext.SaveChangesAsync();
                        }
                        myFridgeIngredient.MyFridgeId = myFridge.Id;

                        _dbContext.MyFridgeIngredient.Add(myFridgeIngredient);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
        }
    }


}

