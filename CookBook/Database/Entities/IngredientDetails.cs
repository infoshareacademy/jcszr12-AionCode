using Database.EnumTypes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class IngredientDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IngredientType Type { get; set; }
        public decimal Calories { get; set; }
        public decimal Proteins { get; set; }
        public decimal Fats { get; set; }
        public decimal Carbohydrates { get; set; }
        public string? ImagePath { get; set; }
        public DateTime AddDate { get; set; }
        public int GI { get; set; }

        [ForeignKey("UserCookBook")]
        public string? UserCookBookId { get; set; }
        public virtual UserCookBook UserCookBook { get; set; }
        public virtual ICollection<IngredientUsed> IngredientsUsed { get; set; }
        public virtual ICollection<IngredientComment> Comments { get; set; }
    }
}
