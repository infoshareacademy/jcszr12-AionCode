using Microsoft.AspNetCore.Mvc;
using CookBook.BuisnesLogic.Services;
using CookBook.BuisnesLogic.Models;


namespace AionCodeMVC.Controllers
{
    public class UsersController : Controller
    {
        //        private readonly UserManager<IdentityUser> _userManager;
        //        private readonly SignInManager<IdentityUser> _signInManager;

 //       private UserRegister _userService;


        public UsersController()
        {
 //           _userService = new UserRegister();
            //            _userManager = userManager;
            //            _signInManager = signInManager;

        }

        public ActionResult Index()
        {
            var model = UserRegister.GetUsersCookBook();
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
            return View();
        }

        // GET: UsersController/Create
        public ActionResult RegisterUser()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        /*       public async Task<IActionResult> RegisterUser([FromBody] User registerUser)
               {
                   try
                   {
                       IdentityUser user1 = new() { Email = registerUser.Email, SecurityStamp = Guid.NewGuid().ToString(), UserName = registerUser.Name };
                       var result = await _userManager.CreateAsync(user1, registerUser.Password);
                       return RedirectToAction(nameof(Index));
                   }
                   catch
                   {
                       return View();
                   }
               }
       */

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Remove(int id)
        {
            return View();
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
