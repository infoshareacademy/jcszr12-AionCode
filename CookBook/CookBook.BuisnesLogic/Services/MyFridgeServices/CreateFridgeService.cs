using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using Database;
using Database.Entities;

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

            }
        }
    }
}
