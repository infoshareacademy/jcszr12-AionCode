using Database.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.BuisnesLogic.DTO
{
    public class RecipeDetailsDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwę")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Wpisz kategorie.")]
        public string? Category { get; set; }
        [Required(ErrorMessage = "Wpisz opis.")]
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public virtual ICollection<IngredientUsed> IngredientUseds { get; set; }
        
       
    }
}
