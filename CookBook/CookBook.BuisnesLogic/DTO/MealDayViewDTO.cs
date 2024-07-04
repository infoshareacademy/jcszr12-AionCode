namespace CookBook.BuisnesLogic.DTO
{
    public class MealDayViewDTO
    {
        public DateTime DayMeal { get; set; }
        public string RecipeMeal { get; set; }
        public int MealDayId { get; set; }
        public string? UserId { get; set; }
        public int? RecipeUsedId { get; set; }
        public string? RecipeName { get; set; }
    }
}
