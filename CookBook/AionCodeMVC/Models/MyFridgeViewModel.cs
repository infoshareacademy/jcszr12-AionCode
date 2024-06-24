using CookBook.BuisnesLogic.DTO;

namespace AionCodeMVC.Models
{
    public class MyFridgeViewModel
    {
        public IEnumerable<MyFridgeDTO> MyFridges { get; set; }
        public List<Tuple<RecipeDTO, List<string>, List<string>>> MyProposedRecipes { get; set; }
    }
}
