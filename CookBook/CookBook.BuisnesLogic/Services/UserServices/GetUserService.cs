using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using CookBook.BuisnesLogic.Models;
using Database;
using Database.Entities;
using Database.EnumTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BuisnesLogic.Services.UserServices
{
    public class GetUserService : IGetUserService
    {
        private IUsersRepository _repository;
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserService(IUsersRepository repository, DatabaseContext dbContext, IMapper mapper)
        {
            _repository = repository;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserCookBookDto>> GetAll()
        {
            List<Database.Entities.UserCookBook>? usersDb = await _dbContext.Users.OrderBy(user => user.UserName).ToListAsync();
            var users = _mapper.Map<List<UserCookBookDto>>(usersDb);

            return users;
        }

        public CookBook.BuisnesLogic.Models.UserCookBook GetByID(string id)
        {
            return _repository.GetByID(id);
        }

    }
}
