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
        [Required(ErrorMessage = "Wpisz tekst.")]
        public string Name { get; set; }
        [DisplayName("Opis")]
        [Required(ErrorMessage = "Wpisz tekst.")]
        public string Description { get; set; }
        [DisplayName("Typ")]
        [Required(ErrorMessage = "Wybierz typ.")]
        public IngredientType Type { get; set; }
        [Required(ErrorMessage = "Wpisz liczbę.")]
        [DisplayName("Kalorie [100g]")]
        public decimal Calories { get; set; }
        [DisplayName("Białko [g]")]
        [Required(ErrorMessage = "Wpisz liczbę.")]
        public decimal Proteins { get; set; }
        [Required(ErrorMessage = "Wpisz liczbę.")]
        [DisplayName("Tłuszcz [g]")]
        public decimal Fats { get; set; }
        [Required(ErrorMessage = "Wpisz liczbę.")]
        [DisplayName("Węglowodany [g]")]
        public decimal Carbohydrates { get; set; }
        public string? ImagePath { get; set; }
        [DisplayName("Data dodania")]
        [Required(ErrorMessage = "Wybierz poprawną datę.")]
        public DateTime AddDate { get; set; }
        [DisplayName("Indeks Glikemiczny")]
        [Required(ErrorMessage = "Wpisz liczbę.")]
        public int GI { get; set; }
        public int? UserCookBookId { get; set; }
    }
}
