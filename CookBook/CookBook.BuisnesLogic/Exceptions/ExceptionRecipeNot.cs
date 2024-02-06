using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Exceptions
{
    public class ExceptionRecipeNot : Exception
    {
        public ExceptionRecipeNot() : base("Brak takiego ID!")
        { }

    }
}