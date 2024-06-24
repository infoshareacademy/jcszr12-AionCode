using CookBook.BuisnesLogic.DTO;

namespace AionCodeMVC.Models
{
    public class MyFridgeViewModel
    {
        public IEnumerable<MyFridgeDTO> MyFridges { get; set; }
        public IEnumerable<RecipeDTO> MyProposedRecipes { get; set; }
    }
}
