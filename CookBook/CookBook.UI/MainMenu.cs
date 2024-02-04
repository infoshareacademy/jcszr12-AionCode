using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.UI
{
    public static class MainMenu
    {
        public static string Display()
        {
            Console.Clear();
            Menu MainMenu = new Menu("Menu logowania:");
            MainMenu.AddPosition("Zaloguj się", "loginmenu");
            MainMenu.AddPosition("Zaloguj się jako gość", "guestmenu");
            MainMenu.AddPosition("Zakończ", "exit");

            MainMenu.ShowMenu();
            MainMenu.OptionSelect();

            return MainMenu.MenuActionID[MainMenu.CurrentMenuPosition];
        }
    }
}
