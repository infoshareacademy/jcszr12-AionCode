using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using CookBook.BuisnesLogic.Models;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CookBook.BuisnesLogic.Services.IngredientServices
{
    public class GetIngredientService : IGetIngredientService
    {   

        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public GetIngredientService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IngredientDTO>> GetIngredientDTOListAll()
        {
            List<IngredientDetails>? allIngredientsDetails = await _dbContext.IngredientDetails.ToListAsync();

            var allIngredientsDetailsDTO = _mapper.Map<List<IngredientDTO>>(allIngredientsDetails);

            return allIngredientsDetailsDTO;
        }


        public Ingredient GetByID(int id)
        {
            // to do -> return by name not by id ??
            return new Ingredient();
            //return _repository.GetByID(id);
        }
    }
}
