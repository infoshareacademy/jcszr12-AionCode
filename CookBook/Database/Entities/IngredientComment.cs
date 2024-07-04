using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class IngredientComment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("IngredientDetails")]
        public int IngredientDetailsId { get; set; }
        public virtual IngredientDetails IngredientDetails { get; set; }
    }
}
