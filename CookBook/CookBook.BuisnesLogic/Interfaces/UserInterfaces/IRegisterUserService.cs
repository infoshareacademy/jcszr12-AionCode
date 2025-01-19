using CookBook.BuisnesLogic.DTO;
using Microsoft.AspNetCore.Identity;

namespace CookBook.BuisnesLogic.Interfaces.UserInterfaces
{
    public interface IRegisterUserService
    {
        public Task<IdentityResult> RegisterUser(RegisterDto user);
    }
}
