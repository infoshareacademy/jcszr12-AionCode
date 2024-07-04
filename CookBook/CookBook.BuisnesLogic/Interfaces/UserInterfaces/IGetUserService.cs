using CookBook.BuisnesLogic.DTO;

namespace CookBook.BuisnesLogic.Interfaces.UserInterfaces
{
    public interface IGetUserService
    {
        public Task<IEnumerable<UserCookBookDto>> GetAll();
        public Task<IEnumerable<UserCookBookDto>> GetUsersByText(string searchText);
        public Task<UserCookBookDto> GetByID(string id);
        public Task<string> LoggedUserIdAsync();
        public Task<UserCookBookDto> AboutMe(string userId);
    }
}
