using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class IngridientUsed
    {
        public int Id { get; set; }
        public DateTime AddDate { get; set; }

        [ForeignKey("RecipeDetails")]
        public int RecipeDetailsId { get; set; }
        public virtual RecipeDetails RecipeDetails { get; set; }
        [ForeignKey("IngredientDetails")]
        public int IngridientDetailsId { get; set; }
        public virtual IngredientDetails IngredientDetails { get; set; }
        public decimal Weight { get; set; }

    }
}
