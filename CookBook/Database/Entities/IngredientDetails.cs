using Database.EnumTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int? UserCookBookId { get; set; }
        public virtual UserCookBook UserCookBook { get; set; }

        public virtual ICollection<IngredientUsed> IngredientsUsed { get; set; }

    }
}
