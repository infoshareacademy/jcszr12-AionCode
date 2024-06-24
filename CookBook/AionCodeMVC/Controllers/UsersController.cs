using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using CookBook.BuisnesLogic.Models;
using CookBook.BuisnesLogic.Services.UserServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Cryptography;
using System.Text;


namespace AionCodeMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IRegisterUserService _registerUserService;
        private readonly IGetUserService _getUserService;
        private readonly IDeleteUserService _deleteUserService;
        private readonly IEditUserService _editUserService;

        private readonly SignInManager<Database.Entities.UserCookBook> _signInManager;
        private readonly UserManager<Database.Entities.UserCookBook> _userManager;
        private readonly IMapper _mapper;

        public UsersController(IRegisterUserService registerUserService, IGetUserService GetUserService, IDeleteUserService DeleteUserService, IEditUserService EditUserService, SignInManager<Database.Entities.UserCookBook> signInManager, UserManager<Database.Entities.UserCookBook> userManager, IMapper mapper)
        {
            _registerUserService = registerUserService;
            _getUserService = GetUserService;
            _deleteUserService = DeleteUserService;
            _editUserService = EditUserService;

            _signInManager = signInManager;
            _userManager = userManager;

            _mapper = mapper;
        }

        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Index(string searchText)
        {
            IEnumerable<UserCookBookDto>? model;
            if (!searchText.IsNullOrEmpty())
            {
                ViewData["SearchText"] = searchText;
                model = await _getUserService.GetUsersByText(searchText);
            }
            else
            {
                model = await _getUserService.GetAll();
            }
            return View(model);
        }

        // GET: UsersController
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.UserName);
                    if (user is not null)
                    {
                        if (await _userManager.IsInRoleAsync(user, "Admin"))
                        {
                            return RedirectToAction("Index", "Users");
                        }
                        return RedirectToAction("Index", "Home");
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Błędne dane logowania. Sprawdź nazwę i hasło");

            }
            return View();
        }

        [Authorize(Policy = "StdUser")]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // GET: UsersController/Details/5
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Details(string id)
        {
            var model = await _getUserService.GetByID(id);
            return View(model);
        }

        // GET: UsersController/Create
        public ActionResult RegisterUser()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterUser(RegisterDto user)
        {
            var result = await _registerUserService.RegisterUser(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    TempData["ErrorMessages"] += error.Description;
                    return RedirectToAction("RegisterUser", "Users");
                }
            }
            else
            {
                TempData["SuccessMessage"] = "Sprawdź swoją pocztę email w celu potwierdzenia adresu.";
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }

        // GET: UsersController/Edit/5
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Edit(string id)
        {
            var model = await _getUserService.GetByID(id);
            return View(model);
        }

        [Authorize(Policy = "Admin")]
        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, UserCookBookDto user)
        {
            var result = await _editUserService.EditUser(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    TempData["ErrorMessages"] += error.Description;
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["SuccessMessage"] = "Aktualizacja danych użytkownika powiodła się";
            return RedirectToAction(nameof(Index));

        }

        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> ChangePassword(string id)
        {
            var user = await _getUserService.GetByID(id);
            var model = _mapper.Map<ChangePasswordDto>(user);

            return View(model);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(string id, ChangePasswordDto user)
        {
            var result = await _editUserService.ChangePassword(id, user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    TempData["ErrorMessages"] += error.Description;
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["SuccessMessage"] = "Hasło zostało zmienione pomyślnie";
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "StdUser")]
        public async Task<ActionResult> ChangeMyPassword()
        {
            var userId = _userManager.GetUserId(User);

            if (userId != null)
            {
                var user = await _getUserService.GetByID(userId);
                var model = _mapper.Map<ChangePasswordDto>(user);
                return View(model);
            }

            return RedirectToAction(nameof(AccessDenied));
        }

        [Authorize(Policy = "StdUser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeMyPassword(ChangePasswordDto user)
        {
            var id = _userManager.GetUserId(User);

            var result = await _editUserService.ChangeMyPassword(id, user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    TempData["ErrorMessages"] += error.Description;
                }

                return View();
            }
            TempData["SuccessMessage"] = "Hasło zostało zmienione pomyślnie";
            return View();
        }

        // GET: UsersController/Delete/5
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Delete(string id)
        {
            var model = await _getUserService.GetByID(id);
            return View(model);
        }

        // POST: UsersController/Delete/5
        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task <ActionResult> Delete(string id, UserCookBookDto user)
        {
            var result = await _deleteUserService.DeleteUser(id);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    TempData["ErrorMessages"] += error.Description;
                }
                return RedirectToAction(nameof(Index));
            }
            TempData["SuccessMessage"] = "Uzytkownik został skasowany pomyślnie";
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "StdUser")]
        public async Task <ActionResult> AboutMe()
        {
            var userId = _userManager.GetUserId(User);

            if (userId != null)
            {
                var model = await _getUserService.AboutMe(userId);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "StdUser")]
        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> AboutMe(UserCookBookDto user)
        {
            var userId = _userManager.GetUserId(User);

            if (userId != null)
            {
                var result = await _editUserService.EditMyself(userId, user);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        TempData["ErrorMessages"] += error.Description;
                    }
                    return RedirectToAction(nameof(Index));
                }
                TempData["SuccessMessage"] = "Dane użytkownika zostały zaktualizowane pomyślnie";
                return RedirectToAction(nameof(AboutMe));
            }
            return RedirectToAction(nameof(AccessDenied));
        }

        public async Task<ActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["ErrorMessages"] += "Autoryzacja nie powiodła się";
                return RedirectToAction("Index", "Home");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Dziękujemy za potwierdzenie adresu mailowego. Możesz zalogować sie na swoje konto.";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["ErrorMessages"] += "Autoryzacja nie powiodła się";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
