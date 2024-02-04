using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.UI
{
    internal class AdminMenu
    {
        public static string Display()
        {
            Console.Clear();
            Menu AdminMenu = new Menu("Menu administratora:");
            AdminMenu.AddPosition("Lista użytkowników", "userlist");
            AdminMenu.AddPosition("Użytkownicy oczekujacy na zatwierdzenie", "userpending");
            AdminMenu.AddPosition("Wyloguj się", "mainmenu");

            AdminMenu.ShowMenu();
            AdminMenu.OptionSelect();

            return AdminMenu.MenuActionID[AdminMenu.CurrentMenuPosition];
        }
    }
}
