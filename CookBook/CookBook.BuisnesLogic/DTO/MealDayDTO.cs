namespace AionCodeMVC.Controllers
{
    public class MealDayDTO
    {
        public DateTime Day { get; set; }
        public DateTime AddDate { get; set; }

        public string? UserCookBookId { get; set; } = null;
    }
}