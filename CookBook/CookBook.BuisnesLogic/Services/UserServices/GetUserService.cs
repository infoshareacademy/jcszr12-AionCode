using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.Services.UserServices
{
    public class GetUserService : IGetUserService
    {
        private IUsersRepository _repository;
        public GetUserService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<UserCookBook> GetAll()
        {
            return _repository.GetAll();
        }

        public UserCookBook GetByID(int id)
        {
            return _repository.GetByID(id);
        }

    }
}
