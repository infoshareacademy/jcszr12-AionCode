﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class IngredientUsed
    {
        public int Id { get; set; }
        public DateTime AddDate { get; set; }

        [ForeignKey("RecipeDetails")]
        public int? RecipeDetailsId { get; set; }
        public virtual RecipeDetails RecipeDetails { get; set; }
        [ForeignKey("IngredientDetails")]
        public int? IngredientDetailsId { get; set; }
        public virtual IngredientDetails IngredientDetails { get; set; }
        public decimal Weight { get; set; }

    }
}
