﻿namespace CookBook.BuisnesLogic.DTO
{
    public class RecipeDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public IEnumerable<RecipeCommentDTO>? Comments { get; set; }
        public IEnumerable<RecipeRatingDTO> Ratings { get; set; }

    }
}
