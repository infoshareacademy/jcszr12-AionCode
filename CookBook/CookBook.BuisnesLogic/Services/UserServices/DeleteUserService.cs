using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using Microsoft.AspNetCore.Identity;

namespace CookBook.BuisnesLogic.Services.UserServices
{
    public class DeleteUserService : IDeleteUserService
    {
        private IUsersRepository _repository;
        private readonly UserManager<Database.Entities.UserCookBook> _userManager;

        public DeleteUserService(IUsersRepository repository, UserManager<Database.Entities.UserCookBook> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<IdentityResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                return result;
            }
            else
            {
                return IdentityResult.Failed(new IdentityError { Description = "Użytkownik nie istnieje" });
            }
        }

    }
}
