using Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.DTO
{
    public class RecipeRatingDTO
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public int RecipeDetailsId { get; set; }
    }
}
