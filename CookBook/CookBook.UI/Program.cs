using CookBook.BuisnesLogic.Models;
using System;

namespace CookBook.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Roles role = new Roles();
            string action = MainMenu.Display();
            do
            {
              UiActions.ActionRun(ref action, ref role);
            } while (action != "exit");           
         }
    }
}
