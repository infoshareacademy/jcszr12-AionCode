using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class RecipeComment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("RecipeDetails")]
        public int RecipeDetailsId { get; set; }
        public virtual RecipeDetails RecipeDetails { get; set; }
    }
}
