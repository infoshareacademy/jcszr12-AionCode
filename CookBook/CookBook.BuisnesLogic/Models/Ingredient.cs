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
        public decimal Calories { get; set; }
        [Display(Name = "Białko [g]")]
        public decimal Proteins { get; set; }
        [Display(Name = "Tłuszcze [g]")]
        public decimal Fats { get; set; }
        [Display(Name = "Węglowodany [g]")]
        public decimal Carbohydrates { get; set; }
        [Display(Name = "Zdjęcie")]
        public DateTime AddDate { get; set; }
        public int GI {  get; set; }
        public string? PhotoUrl { get; set; }

    }
}
/*Id int
Name nvarchar
Description nvarchar
Type nvarchar
Calories decimal
Proteins decimal
Fats decimal
Carbohydrates decimal
ImagePath ncarchar
AddDate date
GI int
UserCookBookId integer*/