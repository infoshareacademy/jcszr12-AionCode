﻿
namespace CookBook.BuisnesLogic.Models
{
    internal class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }    
        public string Description { get; set; }
        public List<string> IngredientList { get; set; }
        //public double Rating { get; set; }

    }

}
