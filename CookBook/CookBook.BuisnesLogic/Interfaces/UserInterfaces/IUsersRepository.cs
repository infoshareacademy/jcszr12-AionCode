using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.Interfaces.UserInterfaces
{
    public interface IUsersRepository
    {
        public IEnumerable<UserCookBook> GetAll();
        public UserCookBook GetByID(string id);
        public void RegisterUser(UserCookBook user);
        public void DeleteUser(string id);
        public void EditUser(UserCookBook user);
    }
}
