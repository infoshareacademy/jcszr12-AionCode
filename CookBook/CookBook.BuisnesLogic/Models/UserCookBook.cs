using Microsoft.AspNetCore.Identity;

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
