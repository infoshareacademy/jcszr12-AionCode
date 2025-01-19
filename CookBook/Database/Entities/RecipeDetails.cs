using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class RecipeDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime AddDate { get; set; }

        [ForeignKey("UserCookBook")]
        public string? UserCookBookId { get; set; }
        public UserCookBook UserCookBook { get; set; }
        public virtual ICollection<RecipeUsed> RecipesUsed { get; set; }
        public virtual ICollection<IngredientUsed> IngredientsUsed { get; set; }
    }
}
