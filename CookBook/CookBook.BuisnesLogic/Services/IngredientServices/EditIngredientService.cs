using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;


namespace CookBook.BuisnesLogic.Services.IngredientServices
{
    public class EditIngredientService : IEditIngredientService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public EditIngredientService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Edit(IngredientEditDTO ingredientEdited)
        {
            var ingredientEditedMapped = _mapper.Map<IngredientDetails>(ingredientEdited);

            var ingredientInDatabase = await _dbContext.IngredientDetails.Where(x => x.Id == ingredientEdited.Id).FirstOrDefaultAsync();

            if (ingredientInDatabase != null)
            {
                _dbContext.IngredientDetails.Entry(ingredientInDatabase).CurrentValues.SetValues(ingredientEditedMapped);
                _dbContext.SaveChanges();
            }
        }

    }
}
