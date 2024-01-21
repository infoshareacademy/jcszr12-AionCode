using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.UI
{
    internal static class AdminMenu
    {
        public static void Display ()
        {
            Console.Clear();

            Menu AdminMenu = new Menu("Administrator manu");
            AdminMenu.AddPosition("Opcja1","op1");
            AdminMenu.AddPosition("Opcja2","op2");
            AdminMenu.AddPosition("Opcja3","op3");

            AdminMenu.ShowMenu();
            AdminMenu.OptionSelect();

        }
    }
}
