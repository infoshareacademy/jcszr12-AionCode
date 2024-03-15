using CookBook.BuisnesLogic.Models;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;

namespace CookBook.BuisnesLogic.Services.UserServices
{
    public class RegisterUserService : IRegisterUserService
    {
        private IUsersRepository _repository;
        public RegisterUserService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public void RegisterUser(UserCookBook user)
        {
            _repository.RegisterUser(user);
        }

    }
}
