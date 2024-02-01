
namespace CookBook.BuisnesLogic.Models
{
    internal class Recipe
    {
        public static int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }

        public Recipe(string recipeName, string recipeDescription, double recipeScore)
        {
            Name = recipeName;
            Description = recipeDescription;
            Id++;
        }
        public Recipe(string recipeName, string recipeDescription)
        {
            Name = recipeName;
            Description = recipeDescription;
            Id++;
        }
    }

}
