using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using CookBook.BuisnesLogic.Models;
using CookBook.BuisnesLogic.Services.UserServices;
using Microsoft.AspNetCore.Mvc;


namespace AionCodeMVC.Controllers
{
    public class UsersController : Controller
    {
        private IRegisterUserService _registerUserService;
        private IGetUserService _getUserService;
        private IDeleteUserService _deleteUserService;
        private IEditUserService _editUserService;

        public UsersController(IRegisterUserService registerUserService, IGetUserService GetUserService, IDeleteUserService DeleteUserService, IEditUserService EditUserService)
        {
            _registerUserService = registerUserService;
            _getUserService = GetUserService;
            _deleteUserService = DeleteUserService;
            _editUserService = EditUserService;
        }

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
        public ActionResult RegisterUser(UserCookBook model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                _registerUserService.RegisterUser(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
      
        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _getUserService.GetByID(id);
            return View(model);
        }

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
        public ActionResult Delete(int id)
        {
            var model = _getUserService.GetByID(id);
            return View(model);
        }

        // POST: UsersController/Delete/5
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
