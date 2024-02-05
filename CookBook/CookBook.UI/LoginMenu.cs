using CookBook.BuisnesLogic.Models;
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
        public static (string,Roles) Login()
        {
            string action = "";
            string login, password;
            Roles role = new();

            GetLoginData(out login, out password);
            (bool accessGranted, string userType) = isCorrectLoginData(login, password); // zamienić na serwis
            
            if (accessGranted)
            {
                if (userType == "stduser") { action = "stdusermenu"; role = Roles.StdUser; }
                else { action = "adminmenu"; role= Roles.Admin; }
            }
            else action = "mainmenu";

            return (action, role);
        }
        public static void GetLoginData(out string login, out string password)
        {
            Console.Clear();

            Console.Write("Podaj login: ");
            login = Console.ReadLine();
            Console.Write("Podaj hasło: ");
            password = GetPassword();

            if (login == "" || password == "")
            {
                Console.WriteLine("Podaj poprawne dane logowania");
            }
            
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
