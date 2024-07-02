using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Policy;
using CookBook.BuisnesLogic.Models;
using CookBook.BuisnesLogic.Services.UserServices;

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;

namespace CookBook.BuisnesLogic.Services.UserServices
{
    public class RegisterUserService : IRegisterUserService
    {
        private IUsersRepository _repository;
        private readonly UserManager<Database.Entities.UserCookBook> _userManager;
        private readonly SignInManager<Database.Entities.UserCookBook> _signInManager;
        private readonly IEmailService _emailService;

        public RegisterUserService(IUsersRepository repository, UserManager<Database.Entities.UserCookBook> userManager, SignInManager<Database.Entities.UserCookBook> signInManager, IEmailService emailService)
        {
            _repository = repository;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
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
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(userDb);
                await _userManager.AddToRoleAsync(userDb, "StdUser");

                var confirmationLink = $"Próbujesz założyć własne konto w serwisie CookBook AionCode.\nPotwierdź Twój adres e-mail klikając w poniższy link:\nhttps://localhost:7063/Users/ConfirmEmail?userId={userDb.Id}&token={token}";
                await _emailService.SendEmailAsync(userDb.Email, "CookBook AC - Potwierdz swoj email", confirmationLink);
            }
            return result;
        }

    }
}
