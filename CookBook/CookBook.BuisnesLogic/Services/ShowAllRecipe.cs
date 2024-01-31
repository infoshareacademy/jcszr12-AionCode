using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Services
{
    public class ShowAllRecipe : IShowAllRecipe
    {
        public void DisplayAllRecipes(IEnumerable<Przepisy> recipes)
        {
            try
            {
                foreach (var przepisy in recipes)
            {
                Console.WriteLine($"{przepisy.Id} {przepisy.Kategoria} {przepisy.NazwaPotrawy} {przepisy.Przepis}");
                for (int i = 0; i < przepisy.Skladniki.Count; i++)
                {
                    Console.WriteLine(przepisy.Skladniki[i]);
                }
            }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
        }

    }
}
