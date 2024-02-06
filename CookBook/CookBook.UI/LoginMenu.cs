using CookBook.BuisnesLogic.Models;
using CookBook.BuisnesLogic.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
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

            password = password.Remove(password.Length-1);
            return password;

        }
        public static (bool, string) isCorrectLoginData(string login, string password)
        {
            bool isCorrect = true;
            string userType = "stduser";

            if (login == "Marek") userType = "admin";

            return (isCorrect, userType);    
        }

        public static string NewUserRegister()
        {
            UserCookBook newUser = new UserCookBook();
            string action = "";

            Console.WriteLine("Rejestracja nowego użytkownika\n");
            Console.Write("Nazwa użytkownika: "); newUser.Name = Console.ReadLine();
            Console.Write("E-mail: "); newUser.Email = Console.ReadLine();
            Console.Write("Hasło: "); newUser.Password = GetPassword(); Console.WriteLine();
            newUser.Role = Roles.StdUser;

            if (UserRegister.AddUser(newUser))
            {
                Console.WriteLine("SUKCES! Witamy w gronie użytkowników CookBook AionCode");
                action = "stdusermenu";
            }
            else
            {
                Console.WriteLine("Utworzenie użytkownika nie powiodło się. Zweryfikuj poprawność wprowadzonych danych i spróbuj ponownie.");
                action = "mainmenu";
            }
            Console.WriteLine("\nWciśniej dowolny klawisz, aby kontynuować.");
            Console.ReadKey();
            return action;
        }

        public static void ShowUsersList()
        {
            List<UserCookBook> users = new();

            users = UserRegister.GetUsersCookBook();

            Console.Clear();
            Console.WriteLine("Lista użytkowników systemu CookBook AionCode:\n");

            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id} Nazwa: {user.Name} Email: {user.Email} Rola: {user.Role}");
            }

            Console.WriteLine("\nWciśnij dowolny klawisz, aby kontynuować");
            Console.ReadKey();

        }
    }
}
