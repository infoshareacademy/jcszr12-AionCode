using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class RecipeDetails
    {
        int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime AddDate { get; set; }
        public int UserCookBookId {  get; set; }


    }
}
