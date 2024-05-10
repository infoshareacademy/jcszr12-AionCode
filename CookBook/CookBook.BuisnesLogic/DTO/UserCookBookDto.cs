using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.DTO
{
    public class UserCookBookDto
    {
        [ScaffoldColumn(false)]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Imię i Nazwisko")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Hasło")]
        public string Password { get; set; } = string.Empty;

        public Roles Role { get; set; }

        public DateTime AddDate { get; set; }
    }
}
