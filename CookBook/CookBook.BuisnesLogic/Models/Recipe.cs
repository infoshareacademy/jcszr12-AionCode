
namespace CookBook.BuisnesLogic.Models
{
    internal class Recipe
    {
        private string name;
        private string description;
        private double rating = 0;
        private List<double> scoreList = new List<double>();

        public Recipe(string recipeName, string recipeDescription, double recipeScore)
        {
            name = recipeName;
            description = recipeDescription;
            RateRecipe(recipeScore);
        }
        public Recipe(string recipeName, string recipeDescription)
        {
            name = recipeName;
            description = recipeDescription;
        }

        public void RateRecipe(double rating)
        {
            scoreList.Add(rating);
            CountRating();
        }
        private void CountRating()
        {
            rating = scoreList.Sum() / scoreList.Count;
        }

        public override string ToString()
        {
            return $"{name}\n{description}\nOcena: {rating:0.##}.";
        }
    }
}
