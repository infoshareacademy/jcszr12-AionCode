﻿using Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.DTO
{
    public class RecipeEditDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime AddDate { get; set; }

        [ForeignKey("UserCookBook")]
        public int? UserCookBookId { get; set; }
        public UserCookBook UserCookBook { get; set; }
        public virtual ICollection<RecipeUsed> RecipesUsed { get; set; }
        public virtual ICollection<IngredientUsed> IngredientsUsed { get; set; }
    }
}
