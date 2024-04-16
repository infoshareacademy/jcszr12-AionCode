using Database.Entities;
using Database.EnumTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.DTO
{
    public class IngredientEditDTO
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Opis")] 
        public string Description { get; set; }
        [DisplayName("Typ")]
        public IngredientType Type { get; set; }
        [DisplayName("Kalorie [100g]")]
        public decimal Calories { get; set; }
        [DisplayName("Białko [g]")]
        public decimal Proteins { get; set; }
        [DisplayName("Tłuszcz [g]")]
        public decimal Fats { get; set; }
        [DisplayName("Węglowodany [g]")]
        public decimal Carbohydrates { get; set; }
        public string? ImagePath { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Data dodania")]

        public DateTime AddDate { get; set; }
        [DisplayName("Indeks Glikemiczny")]
        public int GI { get; set; }
        public int? UserCookBookId { get; set; }

        /* public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public IngredientType Type { get; set; }

        public decimal Calories { get; set; }

        public decimal Proteins { get; set; }

        public decimal Fats { get; set; }

        public decimal Carbohydrates { get; set; }
        public string? ImagePath { get; set; }

        public int GI { get; set; }*/
    }
}
