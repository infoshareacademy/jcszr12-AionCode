using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Services
{

    public class RecipeJsonD
    {

        public void DeserializeRecipes()
        {
            string jsonRecipe = File.ReadAllText(@"C:\Users\tomro\OneDrive\Pulpit\Sprint1_tb\CookBook\CookBook.BuisnesLogic\Data\przepisy.json");
            var allJsonRecipe = JsonConvert.DeserializeObject<Przepisy[]>(jsonRecipe);

            var otherClassInstance = new ShowAllRecipe();
            otherClassInstance.DisplayAllRecipes(allJsonRecipe);
            //new object for class ShowAllRecipes
        }
    }
}
