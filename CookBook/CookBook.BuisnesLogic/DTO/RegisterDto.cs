using CookBook.BuisnesLogic.Models;
using System.ComponentModel.DataAnnotations;

namespace CookBook.BuisnesLogic.DTO
{
    public class RegisterDto
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Imię i Nazwisko")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Rola")]
        public Roles Role { get; set; }
    }
}
