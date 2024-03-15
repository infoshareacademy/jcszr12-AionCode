using CookBook.BuisnesLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Interfaces.UserInterfaces
{
    public interface IRegisterUserService
    {
        public void RegisterUser(UserCookBook user);
    }
}
