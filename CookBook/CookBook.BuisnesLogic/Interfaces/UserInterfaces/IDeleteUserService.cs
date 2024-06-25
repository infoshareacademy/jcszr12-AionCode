using Microsoft.AspNetCore.Identity;

namespace CookBook.BuisnesLogic.Interfaces.UserInterfaces
{
    public interface IDeleteUserService
    {
        public Task<IdentityResult> DeleteUser(string id);
    }
}
