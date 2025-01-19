using System.ComponentModel.DataAnnotations;

namespace CookBook.BuisnesLogic.DTO
{
    public class MealDayDTO
    {
        public DateTime Day { get; set; }
        public DateTime AddDate { get; set; }

        public string? UserCookBookId { get; set; }

        //////////////

        [Required(ErrorMessage = "Wybierz żarełko, bo w przeciwnym wypadku \"nici\" z planowania!")]
        public int? RecipeDetailsId { get; set; }
        public string PartOfDay { get; set; }
        public int? MealDayId { get; set; }

        ////////////
        public List<RecipesDetailsShortDTO>? DetailsShort { get; set; }
    }
}
