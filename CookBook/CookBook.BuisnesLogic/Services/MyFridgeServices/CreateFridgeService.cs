using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces;
using Database.Entities;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;

namespace CookBook.BuisnesLogic.Services.MyFridgeServices
{
    public class CreateFridgeService : ICreateFridgeService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IGetUserService _getUserService;

        public CreateFridgeService(DatabaseContext dbContext, IMapper mapper, IGetUserService getUserService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _getUserService = getUserService;
        }

        public async Task AddFridge(MyFridgeDTO fridgeDTO)
        {
            try
            {
                // Konwersja DTO na encję za pomocą Automappera
                var newFridge = _mapper.Map<MyFridge>(fridgeDTO);
                newFridge.UserCookBookId = await _getUserService.LoggedUserIdAsync();

                // Dodawanie nowej lodówki do kontekstu bazy danych
                _dbContext.MyFridge.Add(newFridge);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Obsługa błędów - można zalogować błąd lub wyświetlić komunikat użytkownikowi
                throw ex; // lub inna obsługa błędów
            }
        }
    }
}
