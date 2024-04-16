﻿using Database.Entities;
using Database.EnumTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.DTO
{
    public class IngredientDTO
    {

        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        public IngredientType Type { get; set; }
        [DisplayName("Białko [g]")]
        public decimal Proteins { get; set; }
        [DisplayName("Tłuszcz [g]")]
        public decimal Fats { get; set; }
        [DisplayName("Węglowodany [g]")]
        public decimal Carbohydrates { get; set; }
        [DisplayName("Kalorie [100g]")]
        public decimal Calories { get; set; }
    }
}
