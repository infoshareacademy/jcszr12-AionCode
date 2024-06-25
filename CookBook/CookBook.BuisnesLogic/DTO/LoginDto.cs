using System.ComponentModel.DataAnnotations;

namespace CookBook.BuisnesLogic.DTO
{
    public class LoginDto
    {
        [Display(Name = "Imię i Nazwisko")]
        public string UserName { get; set; }

        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}
