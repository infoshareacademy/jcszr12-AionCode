using System.ComponentModel.DataAnnotations;

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
