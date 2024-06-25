using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using Database;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BuisnesLogic.Services.MyFridgeServices
{
    public class DeleteMyFridgeIngredientService : IDeleteMyFridgeIngredientService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IGetUserService _getUserService;

        public DeleteMyFridgeIngredientService(DatabaseContext dbContext, IGetUserService getUserService)
        {
            _dbContext = dbContext;
            _getUserService = getUserService;
        }

        public async Task DeleteFridgeIngredient(MyFridgeIngredientDTO myFridgeIngredientDTO)
        {
            {
                string userId = await _getUserService.LoggedUserIdAsync();
                // Ensure the user is authenticated
                if (userId == null)
                {
                    throw new UnauthorizedAccessException("User is not authenticated");
                }

                // Find the MyFridgeIngredient entity to delete
                var myFridgeIngredient = await _dbContext.MyFridgeIngredient
                    .FirstOrDefaultAsync(ingredient =>
                        ingredient.Id == myFridgeIngredientDTO.Id &&
                        ingredient.MyFridge.UserCookBook.Id == userId);

                // If the entity is not found, handle the error
                if (myFridgeIngredient == null)
                {
                    throw new KeyNotFoundException("MyFridgeIngredient not found");
                }

                // Remove the entity from the DbContext
                _dbContext.MyFridgeIngredient.Remove(myFridgeIngredient);

                // Save the changes to the database
                await _dbContext.SaveChangesAsync();


            }
        }
    }
}
