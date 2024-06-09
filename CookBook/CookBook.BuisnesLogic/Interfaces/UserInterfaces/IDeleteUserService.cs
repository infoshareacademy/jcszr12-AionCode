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
    public interface IDeleteUserService
    {
        public Task<IdentityResult> DeleteUser(string id);
    }
}
