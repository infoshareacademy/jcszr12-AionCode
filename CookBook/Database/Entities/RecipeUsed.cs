using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class RecipeUsed
    {
        public int Id { get; set; }
        [ForeignKey("RecipeDetails")]
        public int? RecipeDetailsId { get; set; }
        public virtual RecipeDetails RecipeDetails { get; set; }
        public DateTime AddDate { get; set; }
        public string PartOfDay { get; set; }

        [ForeignKey("MealDay")]
        public int? MealDayId { get; set; }
        public virtual MealDay MealDay { get; set; }
    }
}
