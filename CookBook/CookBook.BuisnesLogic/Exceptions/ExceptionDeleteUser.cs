using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Exceptions
{
    internal class ExceptionDeleteUser : Exception
    {
        public ExceptionDeleteUser() : base("Nie udało się usunąć użytkownika")
        {
        }

        public ExceptionDeleteUser(string massager) : base(massager)
        {

        }
       
    }
}
