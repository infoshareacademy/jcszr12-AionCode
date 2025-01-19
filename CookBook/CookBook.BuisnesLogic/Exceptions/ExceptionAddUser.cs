namespace CookBook.BuisnesLogic.Exceptions
{
    internal class ExceptionAddUser : Exception
    {
        public ExceptionAddUser() : base(" Jest już taki użytkownik w bazie danych!")
        {

        }
    }
}
