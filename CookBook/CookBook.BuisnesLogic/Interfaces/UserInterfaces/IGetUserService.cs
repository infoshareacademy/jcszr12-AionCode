using CookBook.BuisnesLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.BuisnesLogic.DTO;

namespace CookBook.BuisnesLogic.Interfaces.UserInterfaces
{
    public interface IGetUserService
    {
        public Task<IEnumerable<UserCookBookDto>> GetAll();
        public UserCookBook GetByID(string id);
    }
}
