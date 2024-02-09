using CookBook.BuisnesLogic.Exceptions;
using CookBook.BuisnesLogic.Models;
using CookBook.BuisnesLogic.Services;
using CookBook.UI.TempTest;
using System.Xml.Linq;

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
            if (!UserRegister.AddUser(NewUser)) Console.WriteLine("\nJest już taki użytkownik!");

            FormsAddUser.ShowAllUsers(UserRegister.GetUsersCookBook());
            Console.WriteLine();
            Console.WriteLine("Podaj login i hasło: ");

            try
            {
                var result = UserLogin.LoginUser(Name: Console.ReadLine(), Password: Console.ReadLine());

                foreach (var VARIABLE in result)
                {
                    Console.WriteLine(@"Witaj : {1} |Id: {0} |email: {2} |rola: {3} ", VARIABLE.Id, VARIABLE.Name, VARIABLE.Email, VARIABLE.Role);
                }
            }
            catch (ExceptionLogin ex)
            {
                Console.WriteLine("Niestety, " + ex.Message);
            }
            Console.WriteLine("Podaj id użytkownika do usunięcia: ");
            Console.WriteLine();
            try
            {
                RemoveUser.UserDelete(int.Parse(Console.ReadLine()));
            }
            catch(ExceptionDeleteUser e)
            {
                Console.WriteLine(e);
            }
            FormsAddUser.ShowAllUsers(UserRegister.GetUsersCookBook());
        }
    }
}
