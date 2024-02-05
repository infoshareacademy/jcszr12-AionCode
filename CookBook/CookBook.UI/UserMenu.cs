using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.UI
{
    public static class UserMenu
    {
        public static string Display()
        {
            Console.Clear();
            Menu UserMenu = new Menu("Menu użytkownika:");
            UserMenu.AddPosition("Lista przepisów", "recipelist");
            UserMenu.AddPosition("Dodaj nowy przepis", "recipeadd");
            UserMenu.AddPosition("Wyloguj", "mainmenu");

            UserMenu.ShowMenu();
            UserMenu.OptionSelect();

            return UserMenu.MenuActionID[UserMenu.CurrentMenuPosition];
        }
    }
}