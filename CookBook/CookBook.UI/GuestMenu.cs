using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.UI
{
    public static class GuestMenu
    {
        public static string Display()
        {
            Console.Clear();
            Menu GuestMenu = new Menu("Menu gościa:");
            GuestMenu.AddPosition("Lista przepisów", "receipelist");
            GuestMenu.AddPosition("Wniosek o utworzenie konta", "registermenu");
            GuestMenu.AddPosition("Cofnij", "mainmenu");

            GuestMenu.ShowMenu();
            GuestMenu.OptionSelect();

            return GuestMenu.MenuActionID[GuestMenu.CurrentMenuPosition];
        }
    }
}
