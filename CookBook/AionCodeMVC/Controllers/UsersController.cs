using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using CookBook.BuisnesLogic.Models;
using CookBook.BuisnesLogic.Services.UserServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


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

        public UsersController(IRegisterUserService registerUserService, IGetUserService GetUserService, IDeleteUserService DeleteUserService, IEditUserService EditUserService, SignInManager<Database.Entities.UserCookBook> signInManager, UserManager<Database.Entities.UserCookBook> userManager)
        {
            _registerUserService = registerUserService;
            _getUserService = GetUserService;
            _deleteUserService = DeleteUserService;
            _editUserService = EditUserService;

            _signInManager = signInManager;
            _userManager = userManager;
        }

        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<UserCookBookDto>? model = await _getUserService.GetAll();
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
                    ModelState.AddModelError("", error.Description);
                    ViewBag.Message += error.Description;
                    ViewBag.Message += " ";
                }
            }
            return RedirectToAction("Index", "Home");
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
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }

                await _editUserService.EditUser(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
            try
            {
                await _deleteUserService.DeleteUser(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
