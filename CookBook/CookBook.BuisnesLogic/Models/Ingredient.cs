using System.ComponentModel.DataAnnotations;

namespace CookBook.BuisnesLogic.Models
{
    public class Ingredient
    {
        [Display(Name = "Lp.")]
        public int Id { get; set; }
        [Display (Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Grupa")]
        public string Type { get; set; }
        [Display(Name = "Kalorie [kcal]")]
        public double Calories { get; set; }
        [Display(Name = "Białko [g]")]
        public double Proteins { get; set; }
        [Display(Name = "Tłuszcze [g]")]
        public double Fats { get; set; }
        [Display(Name = "Węglowodany [g]")]
        public double Carbohydrates { get; set; }
        [Display(Name = "Szacowana cena [zł.]")]
        public decimal Price { get; set; }
    }
}
