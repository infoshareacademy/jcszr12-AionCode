using Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.DTO
{
    public class MyFridgeIngredientDTO
    {
            public int Id { get; set; }
            public int MyFridgeId { get; set; }
            public virtual MyFridge MyFridge { get; set; }
            public int IngredientDetailsId { get; set; }
            public virtual IngredientDetails IngredientDetails { get; set; }
            public DateTime AddDate { get; set; }
            public decimal Weight { get; set; }
    }
}
