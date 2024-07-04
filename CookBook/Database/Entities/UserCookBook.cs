using Microsoft.AspNetCore.Identity;

namespace Database.Entities
{
    public class UserCookBook : IdentityUser
    {
        public virtual ICollection<MealDay> MealDays { get; set; }
        public virtual ICollection<RecipeDetails> RecipesDetails { get; set; }
        public virtual ICollection<IngredientDetails> IngredientsDetails { get; set; }
        public DateTime AddDate { get; set; }
    }

}
