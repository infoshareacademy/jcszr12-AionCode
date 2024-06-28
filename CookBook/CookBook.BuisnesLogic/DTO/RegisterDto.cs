using CookBook.BuisnesLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.DTO
{
    public class RegisterDto
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Podanie nazwy użytkownika jest wymagane")]
        [Display(Name = "Nazwa (nick) użytkownika")]
        [RegularExpression(@"\S+", ErrorMessage = "Nazwa użytkownika nie może zawierać spacji")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Podanie adresu email jest wymagane")]
        [EmailAddress(ErrorMessage = "Błędny adres email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Podanie hasła jest wymagane")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Hasło musi zawierać conajmniej jedną wielką literę, jedną małą, jedną cyfrę i jeden znak specjalny")]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Rola")]
        public Roles Role { get; set; }
    }
}
