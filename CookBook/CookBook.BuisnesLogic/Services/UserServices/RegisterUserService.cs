using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using Microsoft.AspNetCore.Identity;
using System.Web.Mvc;

namespace CookBook.BuisnesLogic.Services.UserServices
{
    public class RegisterUserService : IRegisterUserService
    {
        private IUsersRepository _repository;
        private readonly UserManager<Database.Entities.UserCookBook> _userManager;
        private readonly SignInManager<Database.Entities.UserCookBook> _signInManager;

        public RegisterUserService(IUsersRepository repository, UserManager<Database.Entities.UserCookBook> userManager, SignInManager<Database.Entities.UserCookBook> signInManager)
        {
            _repository = repository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterUser(RegisterDto user)
        {
            Database.Entities.UserCookBook userDb = new()
            {
                UserName = user.UserName,
                Email = user.Email,
                AddDate = DateTime.Now
            };

            var result = await _userManager.CreateAsync(userDb, user.Password!);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userDb, "StdUser");

                await _signInManager.SignInAsync(userDb, false);
            }
            return result;
        }

    }
}
