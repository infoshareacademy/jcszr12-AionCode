using CookBook.BuisnesLogic.Models;
using CookBook.BuisnesLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
