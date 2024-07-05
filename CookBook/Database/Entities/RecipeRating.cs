using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class RecipeRating
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("RecipeDetails")]
        public int RecipeDetailsId { get; set; }
        public virtual RecipeDetails RecipeDetails { get; set; }
    }
}
