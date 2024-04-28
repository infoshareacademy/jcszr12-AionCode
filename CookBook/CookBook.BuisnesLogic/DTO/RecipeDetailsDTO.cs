using Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.BuisnesLogic.DTO
{
    public class RecipeDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
       
    }
}
