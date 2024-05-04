﻿using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using CookBook.BuisnesLogic.Models;
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
        public DeleteUserService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public void DeleteUser (string id)
        {
            _repository.DeleteUser(id);
        }

    }
}
