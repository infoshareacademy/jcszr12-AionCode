using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Exceptions
{
    public class ExceptionAddRecipe : Exception
    {
        public ExceptionAddRecipe() : base("Jest już taki przepis w bazie!")
        { }
        
    }
}
