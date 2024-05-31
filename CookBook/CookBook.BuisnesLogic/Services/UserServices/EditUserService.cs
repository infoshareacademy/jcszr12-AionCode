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

        public async Task EditUser(UserCookBookDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userDto.Id);
            if (user != null)
            {
                user.Email = userDto.Email;
                user.UserName = userDto.UserName;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    // Zaktualizowano pomyślnie
                }
                else
                {
                    // Błęąd aktualizacji
                }

                var userRoles = await _userManager.GetRolesAsync(user);
                if (!userRoles.Contains(userDto.Role.ToString()))
                {
                    // Usuwamy użytkownika z obecnej roli
                    var resultRemoveFromRoles = await _userManager.RemoveFromRolesAsync(user, userRoles);
                    if (resultRemoveFromRoles.Succeeded)
                    {
                        // Dodajemy użytkownika do nowej roli
                        var resultAddToRole = await _userManager.AddToRoleAsync(user, userDto.Role.ToString());
                        if (resultAddToRole.Succeeded)
                        {
                            // rola zaktualizowana
                        }
                        else
                        {
                            // rola nie zaktualizowana
                        }
                    }
                    else
                    {
                        // rola nie zaktualizowana
                    }
                }

                // Zmiana hasła na nowe - zrobic nowy Serwis
//                var resultChangePassword = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
//                if (resultChangePassword.Succeeded)
//                {
//                    // Hasło zmienione
//                }
//                else
//                {
//                    // Wyskoczył błąd
//                }


            }
        }
        public async Task EditMyself(string userId, UserCookBookDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userDto.Id);
            if ((user != null) && (user.Id == userId))
            {
                user.Email = userDto.Email;
                user.UserName = userDto.UserName;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    // Zaktualizowano pomyślnie
                }
                else
                {
                    // Błęąd aktualizacji
                }

                var userRoles = await _userManager.GetRolesAsync(user);
                if (!userRoles.Contains(userDto.Role.ToString()))
                {
                    // Usuwamy użytkownika z obecnej roli
                    var resultRemoveFromRoles = await _userManager.RemoveFromRolesAsync(user, userRoles);
                    if (resultRemoveFromRoles.Succeeded)
                    {
                        // Dodajemy użytkownika do nowej roli
                        var resultAddToRole = await _userManager.AddToRoleAsync(user, userDto.Role.ToString());
                        if (resultAddToRole.Succeeded)
                        {
                            // rola zaktualizowana
                        }
                        else
                        {
                            // rola nie zaktualizowana
                        }
                    }
                    else
                    {
                        // rola nie zaktualizowana
                    }
                }
            }
        }
    }
}
