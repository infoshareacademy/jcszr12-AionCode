using CookBook.BuisnesLogic.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Interfaces.UserInterfaces
{
    public interface IRegisterUserService
    {
        public Task<IdentityResult> RegisterUser(RegisterDto user);
    }
}
