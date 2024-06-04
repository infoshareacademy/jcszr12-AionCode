using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.DTO
{
    public class MealDayViewDTO
    {
        public DateTime DayMeal { get; set; }
        public string RecipeMeal { get; set; }
        public int MealDayId { get; set; }
        public string? UserId { get; set; }
    }
}
