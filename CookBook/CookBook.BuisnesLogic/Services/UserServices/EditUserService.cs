using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using CookBook.BuisnesLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Services.UserServices
{
    public class EditUserService : IEditUserService
    {
        private IUsersRepository _repository;
        public EditUserService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public void EditUser(UserCookBook user)
        {
            _repository.EditUser(user);
        }

    }
}
