using System.ComponentModel.DataAnnotations;

namespace CookBook.BuisnesLogic.Models;

public class Login
{
    [Required]
    public string Name { get; set; }
    [Required ]
    public string Password { get; set; }
}