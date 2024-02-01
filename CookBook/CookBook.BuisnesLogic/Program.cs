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
                Email = FormsAddUser.GetEmail() ,
                Id = 0,
                Name = FormsAddUser.GetName(),
                Password = FormsAddUser.GetPassword()
            };
            UserRegister.AddUser(NewUser);
        }
    }
}
