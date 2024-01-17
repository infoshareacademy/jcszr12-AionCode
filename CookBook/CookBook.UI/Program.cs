namespace CookBook.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu loginMenu = new Menu("Menu logowania:");
            loginMenu.AddPosition("Login", "login");
            loginMenu.AddPosition("Zaloguj się jako gość", "guestmenu");
            loginMenu.AddPosition("Zakończ", "logout");

            loginMenu.ShowMenu();
            loginMenu.OptionSelect();

            Console.WriteLine($"\nWybrano opcję: {loginMenu.MenuActionID[loginMenu.CurrentMenuPosition]}");


        }
    }
}
