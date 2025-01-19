using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using Database;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BuisnesLogic.Services.MyFridgeServices
{
    public class DeleteMyFridgeService : IDeleteMyFridgeService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IGetUserService _getUserService;

        public DeleteMyFridgeService(DatabaseContext dbContext, IGetUserService getUserService)
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

        public async Task DeleteFridge(int id)
        {
            var fridgeIngredientsToDelete = await _dbContext.MyFridgeIngredient
                .Where(i => i.MyFridgeId == id)
                .ToListAsync();

            var fridgeToDelete = await _dbContext.MyFridge
                .FirstOrDefaultAsync(f => f.Id == id);

            if (fridgeToDelete != null)
            {
                if (fridgeIngredientsToDelete.Count > 0)
                {
                    _dbContext.MyFridgeIngredient.RemoveRange(fridgeIngredientsToDelete);
                }

                _dbContext.MyFridge.Remove(fridgeToDelete);

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
