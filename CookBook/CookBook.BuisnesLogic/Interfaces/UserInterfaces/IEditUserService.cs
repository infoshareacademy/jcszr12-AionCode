using CookBook.BuisnesLogic.DTO;
using Microsoft.AspNetCore.Identity;

namespace CookBook.BuisnesLogic.Interfaces.UserInterfaces
{
    public interface IEditUserService
    {
        public Task<IdentityResult> EditUser(UserCookBookDto user);
        public Task<IdentityResult> EditMyself(string userId, UserCookBookDto user);
        public Task<IdentityResult> ChangeMyPassword(string id, ChangePasswordDto userDto);
        public Task<IdentityResult> ChangePassword(string id, ChangePasswordDto userDto);
    }
}
