using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.UI
{
    internal static class LoginMenu
    {
        public static void GetLoginData(out string login, out string password)
        {
            Console.Clear();

            do
            {
                Console.Write("Podaj login: ");
                login = Console.ReadLine();
                Console.Write("Podaj hasło: ");
                password = GetPassword();
            } while (login == "" || password == "");
            
        }

        internal static string GetPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    Console.Write("\b");
                }
            }
            while (key.Key != ConsoleKey.Enter);

            return password;

        }
        public static (bool, string) isCorrectLoginData(string login, string password)
        {
            bool isCorrect = true;
            string userType = "stduser";

            if (login == "Marek") userType = "admin";

            return (isCorrect, userType);    
        }
    }
}
