using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Models
{
    public class UserCookBook : IdentityUser
    {
//        [Display(Name = "Imię i Nazwisko")]
 //       public string UserName { get; set; }

 //       [Display(Name = "Email")]
 //       public string Email { get; set; }
        public DateTime AddDate { get; set; }
    }
}
