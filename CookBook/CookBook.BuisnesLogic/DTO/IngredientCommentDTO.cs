namespace CookBook.BuisnesLogic.DTO
{
    public class IngredientCommentDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public int IngredientDetailsId { get; set; }

    }
}
