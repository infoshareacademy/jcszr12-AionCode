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
        private IRegisterUserService _registerUserService;
        private IGetUserService _getUserService;
        private IDeleteUserService _deleteUserService;
        private IEditUserService _editUserService;

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(IRegisterUserService registerUserService, IGetUserService GetUserService, IDeleteUserService DeleteUserService, IEditUserService EditUserService, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _registerUserService = registerUserService;
            _getUserService = GetUserService;
            _deleteUserService = DeleteUserService;
            _editUserService = EditUserService;

            _signInManager = signInManager;
            _userManager = userManager;
        }

        [Authorize(Policy = "Admin")]
        public ActionResult Index()
        {
            var model = _getUserService.GetAll();
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
                var result =
                    await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

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

                ModelState.AddModelError("", "Invalid login attempt");

            }

            return View();
        }

        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            var model = _getUserService.GetByID(id);
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
        public async Task<ActionResult> RegisterUser(RegisterDto model)
        {
            IdentityUser user = new()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password!);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);

                await _userManager.AddToRoleAsync(user, "StdUser");

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = string.Empty;
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    ViewBag.Message += error.Description;
                    ViewBag.Message += " ";
                }

                return View();
            }
        }

        // GET: UsersController/Edit/5
        [Authorize(Policy = "Admin")]
        public ActionResult Edit(int id)
        {
            var model = _getUserService.GetByID(id);
            return View(model);
        }

        [Authorize(Policy = "Admin")]
        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserCookBook user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }

                _editUserService.EditUser(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        [Authorize(Policy = "Admin")]
        public ActionResult Delete(int id)
        {
            var model = _getUserService.GetByID(id);
            return View(model);
        }

        // POST: UsersController/Delete/5
        [Authorize(Policy = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UserCookBook user)
        {
            try
            {
                 _deleteUserService.DeleteUser(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
