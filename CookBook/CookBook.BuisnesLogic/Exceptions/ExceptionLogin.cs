using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Exceptions
{
    public class ExceptionLogin : Exception
    {
        public ExceptionLogin() : base(" Nieprawidłowy login lub hasło!")
        {
        }
        public ExceptionLogin(string message) : base(message + " Nieprawidłowy login lub hasło!")
        {
        }
        
    }
}
