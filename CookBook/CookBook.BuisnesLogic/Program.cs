using System.Runtime.CompilerServices;
using CookBook.BuisnesLogic.Models;
using CookBook.BuisnesLogic.Services;

namespace CookBook.BuisnesLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Witamy nowego użytkownika \n");
            var NewUser = new UserCookBook()
            {
                Email = "",
                Id = 0,
                Name = Console.ReadLine(),
                Password = GetPassword()

            };
            //UserRegister userCookBook = new UserRegister();
        }

        private static string GetPassword()
        {
            string _password="";
            do
            { 
             _password.Append<>(Console.ReadLine());
            Console.Write("*");
            } while (Console.ReadKey().Key != ConsoleKey.Enter);

            return _password;
        }
    }
}
