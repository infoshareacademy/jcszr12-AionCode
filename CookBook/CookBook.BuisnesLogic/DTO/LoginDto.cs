using CookBook.BuisnesLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.DTO
{
    public class LoginDto
    {
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}
