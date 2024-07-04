namespace CookBook.BuisnesLogic.Exceptions
{
    public class ExceptionAddRecipe : Exception
    {
        public ExceptionAddRecipe() : base("Jest już taki przepis w bazie!")
        { }

    }
}
