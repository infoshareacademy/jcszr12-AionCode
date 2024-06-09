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

        [Required(ErrorMessage = "Podanie Imienia i nazwiska jest wymagane")]
        [Display(Name = "Imię i Nazwisko")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Podanie Email jest wymagane")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Rola")]
        public Roles Role { get; set; }

        public DateTime AddDate { get; set; }
    }
}
