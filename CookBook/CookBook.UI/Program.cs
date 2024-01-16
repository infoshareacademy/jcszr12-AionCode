namespace CookBook.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu loginMenu = new Menu();
            loginMenu.Title("Menu logowania:");
            loginMenu.AddPosition("Login", "login");
            loginMenu.AddPosition("Zaloguj się jako gość", "guestmenu");
            loginMenu.AddPosition("Zakończ", "logout");

            loginMenu.ShowMenu();
            loginMenu.OptionSelect();

        }
    }
}
