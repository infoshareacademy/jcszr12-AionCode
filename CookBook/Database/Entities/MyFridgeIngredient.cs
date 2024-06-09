using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
