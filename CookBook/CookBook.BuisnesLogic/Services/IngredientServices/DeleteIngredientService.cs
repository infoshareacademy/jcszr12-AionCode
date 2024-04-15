using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.AzureInterfaces;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Models;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;

namespace CookBook.BuisnesLogic.Services.IngredientServices
{

    public class DeleteIngredientService : IDeleteIngredientService
    {
        private DatabaseContext _dbContext;
        public DeleteIngredientService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteIngredient(int id)
        {
            IngredientDetails? ingredient = await _dbContext.IngredientDetails.Where(ingredient => ingredient.Id == id).FirstOrDefaultAsync();
            _dbContext.IngredientDetails.Remove(ingredient);
            _dbContext.SaveChanges();
        }
    }
}
