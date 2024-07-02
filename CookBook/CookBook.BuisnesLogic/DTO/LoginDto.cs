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
        [Required(ErrorMessage = "Podanie nazwy użytkownika jest wymagane")]
        [Display(Name = "Nazwa (nick)")]
        [RegularExpression(@"\S+", ErrorMessage = "Nazwa użytkownika nie może zawierać spacji")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Podanie hasła jest wymagane")]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}
