using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class MealDay
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public DateTime AddDate { get; set; }

        [ForeignKey("UserCookBook")]
        public string? UserCookBookId { get; set; }
        public UserCookBook UserCookBook { get; set; }
        public virtual ICollection<RecipeUsed> RecipesUsed { get; set; }
    }
}
