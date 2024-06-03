using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using CookBook.BuisnesLogic.Models;
using CookBook.BuisnesLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CookBook.BuisnesLogic.Services.UserServices
{
    public class EditUserService : IEditUserService
    {
        private IUsersRepository _repository;
        private readonly UserManager<Database.Entities.UserCookBook> _userManager;
        public EditUserService(IUsersRepository repository, UserManager<Database.Entities.UserCookBook> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<IdentityResult> EditUser(UserCookBookDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userDto.Id);
            if (user != null)
            {
                user.Email = userDto.Email;
                user.UserName = userDto.UserName;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    if (!userRoles.Contains(userDto.Role.ToString()))
                    {
                        var resultRemoveFromRoles = await _userManager.RemoveFromRolesAsync(user, userRoles);
                        if (resultRemoveFromRoles.Succeeded)
                        {
                            var resultAddToRole = await _userManager.AddToRoleAsync(user, userDto.Role.ToString());
                            return resultAddToRole;
                        }
                        return resultRemoveFromRoles;
                    }
                    return result;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                return IdentityResult.Failed(new IdentityError { Description = "Użytkownik nie istnieje" });
            }
        }
        public async Task<IdentityResult> EditMyself(string userId, UserCookBookDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userDto.Id);
            if ((user != null) && (user.Id == userId))
            {
                user.Email = userDto.Email;
                user.UserName = userDto.UserName;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    if (!userRoles.Contains(userDto.Role.ToString()))
                    {
                        var resultRemoveFromRoles = await _userManager.RemoveFromRolesAsync(user, userRoles);
                        if (resultRemoveFromRoles.Succeeded)
                        {
                            var resultAddToRole = await _userManager.AddToRoleAsync(user, userDto.Role.ToString());
                            
                            return resultAddToRole;
                        }
                        return resultRemoveFromRoles;
                    }
                    return result;
                }
                else
                {
                    return result;
                }
            }
            return IdentityResult.Failed(new IdentityError { Description = "Użytkownik nie istnieje" });
        }
        public async Task<IdentityResult> ChangeMyPassword(string id, ChangePasswordDto userDto)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var resultChangePassword = await _userManager.ChangePasswordAsync(user, userDto.CurrentPassword, userDto.NewPassword);

                return resultChangePassword;
            }
            return IdentityResult.Failed(new IdentityError { Description = "Użytkownik nie istnieje" });
        }

        public async Task<IdentityResult> ChangePassword(string id, ChangePasswordDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userDto.Id);

            if ((user != null) && (id == user.Id))
            {
               var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
               var resultChangePassword = await _userManager.ResetPasswordAsync(user, resetToken, userDto.NewPassword);

               return resultChangePassword;
            }
            return IdentityResult.Failed(new IdentityError { Description = "Użytkownik nie istnieje" });
        }
    }
}