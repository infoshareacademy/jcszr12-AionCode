using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.UI
{
    public static class MainMenu
    {
        public static void Display()
        {
            Console.Clear();
            Menu MainMenu = new Menu("Menu logowania:");
            MainMenu.AddPosition("Login", "login");
            MainMenu.AddPosition("Zaloguj się jako gość", "guestmenu");
            MainMenu.AddPosition("Zakończ", "logout");

            MainMenu.ShowMenu();
            MainMenu.OptionSelect();

            Console.WriteLine($"\nWybrano opcję: {MainMenu.MenuActionID[MainMenu.CurrentMenuPosition]}");
        }
    }
}
