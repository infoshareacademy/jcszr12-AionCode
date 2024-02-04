using CookBook.BuisnesLogic.Models;
using CookBook.BuisnesLogic.Services;
using CookBook.UI.TempTest;

namespace CookBook.BuisnesLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var NewUser = new UserCookBook()
            {
                Id = 0,
                Name = FormsAddUser.GetName(),
                Email = FormsAddUser.GetEmail(),
                Password = FormsAddUser.GetPassword(),
                Role = Roles.Admin
            };
            if(!UserRegister.AddUser(NewUser)) Console.WriteLine("\nJest już taki użytkownik!");

            FormsAddUser.ShowAllUsers(UserRegister.GetUsersCookBook());
            
        }
    }
}
