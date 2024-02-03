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
                switch (action)
                {
                    case "loginmenu":
                        string login, password;
                        LoginMenu.GetLoginData(out login, out password);
                        (bool accessGranted, string userType) = LoginMenu.isCorrectLoginData(login, password);
                        if (accessGranted)
                        {
                            if (userType == "stduser") action = UserMenu.Display();
                            else action = AdminMenu.Display();
                        }
                        else
                        {
                            Console.WriteLine("Niepoprawne dane logowania");
                            Thread.Sleep(3000);
                            action = MainMenu.Display();
                        }
                        break;
                    case "guestmenu":
                        action = GuestMenu.Display();
                        break;
                    case "mainmenu":
                        action = MainMenu.Display();
                        break;
                    case "adminmenu":
                        action = AdminMenu.Display();
                        break;
                    case "receipelist":
 //                       action = Receipe.GetList();
                        break;
                    case "receipeadd":
 //                       action = Receipe.Add();
                        break;
                    case "receipeshow":
 //                       action = Receipe.Show();
                        break;

// Add rest actions here

                }
            } while (action != "exit");           
         }
    }
}
