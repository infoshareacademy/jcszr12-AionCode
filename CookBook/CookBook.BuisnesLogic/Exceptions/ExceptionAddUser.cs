using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Exceptions
{
    internal class ExceptionAddUser : Exception
    {
        public ExceptionAddUser() : base(" Jest już taki użytkownik w bazie danych!")
        {
           
        }
    }
}
