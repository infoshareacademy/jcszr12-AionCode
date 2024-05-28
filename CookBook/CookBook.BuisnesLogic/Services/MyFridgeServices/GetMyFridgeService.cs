using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using Database.Entities;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces;

namespace CookBook.BuisnesLogic.Services.MyFridgeServices
{
    public class GetMyFridgeService : IGetMyFridgeService
    {

        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IGetUserService _getUserService;

        public GetMyFridgeService(DatabaseContext dbContext, IMapper mapper, IGetUserService userService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _getUserService = userService;
        }

        public async Task<IEnumerable<MyFridgeDTO>> GetAllMyFridges()
        {
            string userId = await _getUserService.LoggedUserIdAsync();


            var myFridges = await _dbContext.MyFridge
                   .Include(f => f.UserCookBook)
                   .Include(f => f.MyFridgeIngredients).ThenInclude(f => f.IngredientDetails) // Załaduj IngredientDetails
                   .Where(f => f.UserCookBook.Id == userId) // Filtruj lodówki dla zalogowanego użytkownika
                   .ToListAsync();

            var myFridgeDTOs = _mapper.Map<IEnumerable<MyFridge>, IEnumerable<MyFridgeDTO>>(myFridges);

            return myFridgeDTOs;
        }

    }
}
