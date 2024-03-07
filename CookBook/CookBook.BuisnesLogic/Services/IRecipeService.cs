using CookBook.BuisnesLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Services
{
    public interface IRecipeService
    {
        public List<Recipe> GetRecipe();




        //IEnumerable<Recipe> GetRecipes();   //Do zmiany
        //Recipe GetById(int id);
        //bool DeleteById(int id);
        //Recipe Create(Recipe newRecipe);
        //bool Update(int id, Recipe recipe);
        
    }
}
