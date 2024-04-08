using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Models;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CookBook.BuisnesLogic.Services.IngredientServices
{
    public class GetIngredientService : IGetIngredientService
    {   //  Db version
        private readonly DatabaseContext _dbContext;

        //private IIngredientRepository _repository;
        public GetIngredientService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Ingredient>> GetAll()
        {
            List<IngredientDetails>? allIngredientsDetails = await _dbContext.IngredientDetails.ToListAsync();
            List<Ingredient> allIngredients = new();

            foreach (var item in allIngredientsDetails)
            {
                //DTO
                Ingredient ingredient = new Ingredient()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Type = item.Type,
                    Calories = item.Calories,
                    Proteins = item.Proteins,
                    Fats = item.Fats,
                    Carbohydrates = item.Carbohydrates,
                    ImagePath = item.ImagePath,
                    AddDate = item.AddDate,
                    GI = item.GI,
                    PhotoUrl = item.ImagePath
                };
                allIngredients.Add(ingredient);
            }

            return allIngredients;
        }


        public Ingredient GetByID(int id)
        {
            return new Ingredient();
            //return _repository.GetByID(id);
        }
    }



    //Repo version
    /*    public class GetIngredientService : IGetIngredientService
    {

        private IIngredientRepository _repository;
        public GetIngredientService(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _repository.GetAll();
        }

        public Ingredient GetByID(int id)
        {
            return _repository.GetByID(id);
        }
    }*/


}
