using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.UI
{
    public class Menu
    {
        public int CurrentMenuPosition { get; set; }
        private string _title { get; set; }
        private List<string> MenuNameList = new List<string>();
        private List<string> MenuActionList = new List<string>();

        public Menu()
        {
            CurrentMenuPosition = 0;
        }
        private enum Actions
        {
            login,
            logout,
            guestmenu,
            usermenu,
            receipeshow
        }

        public void Title(string title)
        {
            _title = title;
        }
        public void AddPosition(string positionName, string action)
        {
            if (Enum.IsDefined(typeof(Actions), action))
            {
                MenuNameList.Add(positionName);
                MenuActionList.Add(action);
            }
        }

        public void ShowMenu()
        {
            var x = 0;

            Console.Clear();
            Console.WriteLine(_title);
            Console.BackgroundColor = ConsoleColor.Black;
            for (var i=0; i < MenuNameList.Count; i++)
            {
                if (i == CurrentMenuPosition) Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"{++x}. {MenuNameList[i]}");
                if (i == CurrentMenuPosition) Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public void OptionSelect()
        {
            do
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (CurrentMenuPosition != 0)
                    {
                        CurrentMenuPosition--;
                        ShowMenu();
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (CurrentMenuPosition != MenuNameList.Count - 1)
                    {
                        CurrentMenuPosition++;
                        ShowMenu();
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                    break;
            } while (true);

        }
    }
}
