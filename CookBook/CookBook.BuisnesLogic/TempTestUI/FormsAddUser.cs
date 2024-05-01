using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.BuisnesLogic.Models;

namespace CookBook.UI.TempTest
{
    public static class FormsAddUser
    {

        public static string GetName()
        {
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();
            return name;
        }

        public static string GetEmail()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            bool isValid = IsValidEmail(email);
            Console.WriteLine("Your email is {0}valid.", isValid ? "" : "in");
            return email;
        }

        public static string GetPassword()
        {
            Console.Write("Enter your password: ");
            var password = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, password.Length - 1);
                    Console.Write("\b \b");
                }

            } while (key.Key != ConsoleKey.Enter);

            return password;

        }
        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static void ShowAllUsers(List<UserCookBook> users)
        {
            Console.WriteLine("\n\n");
            foreach (var user in users)
            {
                Console.WriteLine(@"{0} | użytkownik: {1} | email: {2} | rola: {3}",user.Id,user.UserName,user.Email, user.Role);
            }
          
        }
    }

}
