using CookBook.BuisnesLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.BuisnesLogic.DTO;
using System.Web.Mvc;

namespace CookBook.BuisnesLogic.Interfaces.UserInterfaces
{
    public interface IGetUserService
    {
        public Task<IEnumerable<UserCookBookDto>> GetAll();
        public Task<IEnumerable<UserCookBookDto>> GetUsersByText(string searchText);
        public Task<UserCookBookDto> GetByID(string id);
        public Task<string> LoggedUserIdAsync();
        public Task<UserCookBookDto> AboutMe(string userId);
    }
}
