using Microsoft.AspNetCore.Identity;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class UserCookBook : IdentityUser
    {
 //       public string Id { get; set; }
        public virtual ICollection<MealDay> MealDays { get; set; }
        public virtual ICollection<RecipeDetails> RecipesDetails { get; set; }
        public virtual ICollection<IngredientDetails> IngredientsDetails { get; set; }
//        public string UserName { get; set; }
//        public string Email { get; set; }
//        public byte[] Password { get; set; }
//        public string Role { get; set; }
        public DateTime AddDate { get; set; }
    }

}
