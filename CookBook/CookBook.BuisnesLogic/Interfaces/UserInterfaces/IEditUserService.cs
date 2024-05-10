using CookBook.BuisnesLogic.Models;
using CookBook.BuisnesLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Interfaces.UserInterfaces
{
    public interface IEditUserService
    {
        public Task EditUser(UserCookBookDto user);
    }
}
