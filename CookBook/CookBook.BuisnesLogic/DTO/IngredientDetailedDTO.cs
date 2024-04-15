using Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.DTO
{
    public class IngredientDetailedDTO
    {

        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Opis")]
        public string Description { get; set; }
        [DisplayName("Typ")]
        public string Type { get; set; }
        [DisplayName("Kalorie [100g]")]
        public decimal Calories { get; set; }
        [DisplayName("Białko [g]")]
        public decimal Proteins { get; set; }
        [DisplayName("Tłuszcz [g]")]
        public decimal Fats { get; set; }
        [DisplayName("Węglowodany [g]")]
        public decimal Carbohydrates { get; set; }
        public string? ImagePath { get; set; }
        [DisplayName("Indeks Glikemiczny")]
        public int GI { get; set; }
    }
}