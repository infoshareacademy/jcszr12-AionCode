using Database.Entities;

namespace CookBook.BuisnesLogic.DTO
{
    public class MyFridgeIngredientDTO
    {
        public int Id { get; set; }
        public int MyFridgeId { get; set; }
        public virtual MyFridge MyFridge { get; set; }
        public int IngredientDetailsId { get; set; }
        public virtual IngredientDetailedDTO IngredientDetails { get; set; }
        public DateTime AddDate { get; set; }
        public decimal Weight { get; set; }
    }
}
