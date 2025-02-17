﻿using CookBook.BuisnesLogic.Models;
using System.ComponentModel.DataAnnotations;

namespace CookBook.BuisnesLogic.DTO
{
    public class ChangePasswordDto
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Imię i Nazwisko")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Rola")]
        public Roles Role { get; set; }

        [Required(ErrorMessage = "Podanie aktualnego hasła jest wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Aktualne hasło")]
        public string CurrentPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Podanie nowego hasła jest wymagane")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Hasło musi zawierać conajmniej jedną wielką literę, jedną małą, jedną cyfrę i jeden znak specjalny")]
        [Display(Name = "Nowe hasło")]
        public string NewPassword { get; set; } = string.Empty;
         
        [Required(ErrorMessage = "Potwierdzenie nowego hasła jest wymagane")]
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź nowe hasło")]
        [Compare("NewPassword", ErrorMessage = "Nowe hasło i jego potwierdzenie nie są identyczne")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
