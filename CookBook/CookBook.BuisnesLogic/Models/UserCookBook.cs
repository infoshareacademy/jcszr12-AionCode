using Microsoft.AspNetCore.Identity;

namespace CookBook.BuisnesLogic.Models
{
    public class UserCookBook : IdentityUser
    {
        public DateTime AddDate { get; set; }
    }
}
