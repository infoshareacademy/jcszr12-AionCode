using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class MyFridgeIngredient
    {
        public int Id { get; set; }
        [ForeignKey("MyFridge")]
        public int MyFridgeId { get; set; }
        public virtual MyFridge MyFridge { get; set; }

        [ForeignKey("IngredientDetails")]
        public int IngredientDetailsId { get; set; }
        public virtual IngredientDetails IngredientDetails { get; set; }
        public DateTime AddDate { get; set; }

        public decimal Weight { get; set; }
    }
}
