using Database.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookBook.BuisnesLogic.DTO
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Descripton { get; set; }
        public string ImagePath { get; set; }
    }
}
