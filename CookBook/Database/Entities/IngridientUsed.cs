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
        int Id { get; set; }
        DateTime AddDate { get; set; }
        int RecipeDetailsId { get; set; }
        public virtual RecipeDetails RecipeDetails { get; set; }
        int IngridientDetailsId { get; set; }
        public virtual IngredientDetails IngredientDetails { get; set; }
        decimal Weight { get; set; }
        
    }
}
