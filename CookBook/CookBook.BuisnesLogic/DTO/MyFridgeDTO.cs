using Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.DTO
{
    public class MyFridgeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserCookBookId { get; set; }

        public virtual ICollection<MyFridgeIngredientDTO> MyFridgeIngredients { get; set; }  // Kolekcja składników
    }
}
