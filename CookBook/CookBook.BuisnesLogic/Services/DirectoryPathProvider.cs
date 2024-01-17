namespace CookBook.BuisnesLogic.Services;

public static class DirectoryPathProvider
{
    public static string GetSolutionDirectoryInfo()
    {
        return Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "dataUser.json");
    }
}