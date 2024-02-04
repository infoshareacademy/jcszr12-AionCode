using System;

namespace CookBook.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string action = MainMenu.Display();
            do
            {
              uiActions.ActionRun(ref action);
            } while (action != "exit");           
         }
    }
}
