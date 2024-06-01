using Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.DTO
{
    public class MealDayDTO
    {
        public DateTime Day { get; set; }
        public DateTime AddDate { get; set; }

       public string? UserCookBookId { get; set; }

        //////////////
        public int? RecipeDetailsId { get; set; }
         public string PartOfDay { get; set; }
         public int? MealDayId { get; set; }
    }
}
