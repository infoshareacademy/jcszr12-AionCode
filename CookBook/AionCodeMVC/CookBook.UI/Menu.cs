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
        private string Title { get; }
        private List<string> _menuNameList = new List<string>();
        private List<string> _menuActionID = new List<string>();

        public List<string> MenuNameList
        {
            get { return _menuNameList; }
        }
        public List<string> MenuActionID
        {
            get { return _menuActionID; }
        }
        public Menu(string title)
        {
            CurrentMenuPosition = 0;
            Title = title;
        }
        //        private enum Actions
        //        {
        //            login,
        //            logout,
        //            guestmenu,
        //            usermenu,
        //            receipeshow
        //        }

        public void AddPosition(string positionName, string actionID)
        {
 //           if (Enum.IsDefined(typeof(Actions), actionID))
 //           {
                MenuNameList.Add(positionName);
                MenuActionID.Add(actionID);
 //           }
        }

        public void ShowMenu()
        {
            var x = 0;

            Console.Clear();
            Console.WriteLine(Title);
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
                Console.CursorVisible = false;
                
               
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
