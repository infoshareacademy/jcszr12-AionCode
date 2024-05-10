﻿using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using CookBook.BuisnesLogic.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    // Zaktualizowano pomyślnie
                }
                else
                {
                    // Obsłuż błędy aktualizacji
                }
            }
            else
            {
                throw new Exception("Uzytkownik nie istnieje");
            }
        }

    }
}
