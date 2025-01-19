using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using CookBook.BuisnesLogic.Models;
using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CookBook.BuisnesLogic.Services.UserServices
{
    public class GetUserService : IGetUserService
    {
        private IUsersRepository _repository;
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<Database.Entities.UserCookBook> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetUserService(IUsersRepository repository, DatabaseContext dbContext, IMapper mapper, UserManager<Database.Entities.UserCookBook> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _dbContext = dbContext;
            _mapper = mapper;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<UserCookBookDto>> GetAll()
        {
            List<Database.Entities.UserCookBook> usersDb = await _dbContext.Users.OrderBy(user => user.UserName).ToListAsync();

            var users = new List<UserCookBookDto>();
            foreach (var user in usersDb)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();

                var userToAdd = new UserCookBookDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = (Roles)Enum.Parse(typeof(Roles), role),
                    AddDate = user.AddDate
                };
                users.Add(userToAdd);
            }
            return users;
        }

        public async Task<IEnumerable<UserCookBookDto>> GetUsersByText(string searchText)
        {
            List<Database.Entities.UserCookBook> usersDb = await _dbContext.Users.Where(user => user.UserName.Contains(searchText)).OrderBy(user => user.UserName).ToListAsync();

            var users = new List<UserCookBookDto>();
            foreach (var user in usersDb)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();

                var userToAdd = new UserCookBookDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = (Roles)Enum.Parse(typeof(Roles), role),
                    AddDate = user.AddDate
                };
                users.Add(userToAdd);
            }
            return users;
        }

        public async Task<UserCookBookDto> GetByID(string id)
        {
            Database.Entities.UserCookBook userDb = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            var roles = await _userManager.GetRolesAsync(userDb);
            var role = roles.FirstOrDefault();

            var user = new UserCookBookDto
            {
                Id = userDb.Id,
                UserName = userDb.UserName,
                Email = userDb.Email,
                Role = (Roles)Enum.Parse(typeof(Roles), role),
                AddDate = userDb.AddDate
            };
            return user;
        }

        public async Task<string> LoggedUserIdAsync()
        {
            ClaimsPrincipal loggedUser = _httpContextAccessor.HttpContext.User;

            IdentityUser userData = await _userManager.GetUserAsync(loggedUser);
            if (userData != null)
            {
                return userData.Id;
            }
            else
            {
                return null;
            }
        }

        public async Task<UserCookBookDto> AboutMe(string userId)
        {
            Database.Entities.UserCookBook userDb = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            var roles = await _userManager.GetRolesAsync(userDb);
            var role = roles.FirstOrDefault();

            var user = new UserCookBookDto
            {
                Id = userDb.Id,
                UserName = userDb.UserName,
                Email = userDb.Email,
                Role = (Roles)Enum.Parse(typeof(Roles), role),
                AddDate = userDb.AddDate
            };
            return user;
        }
    }
}
