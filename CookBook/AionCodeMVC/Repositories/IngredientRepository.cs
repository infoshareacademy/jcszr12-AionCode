using AionCodeMVC.Interfaces;
using AionCodeMVC.Models;

namespace AionCodeMVC.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private List<Ingredient> _ingredients = new List<Ingredient>
        {
            new Ingredient{ Id =1, Name = "Marcherw", Type = "Warzywo", Description = "Warzywo korzeniowe, pomarańczowe", Calories = 25, Carbohydrates = 5.8, Proteins = 0.6, Fats = 0.1, Price = 3.50m},
            new Ingredient{ Id =2, Name = "Banan", Type = "Owoc", Description = "Owoc egzotyczny, żółty", Calories = 90, Carbohydrates = 23, Proteins = 1.1, Fats = 0.3, Price = 5.20m},
            new Ingredient{ Id =3, Name = "Kurczak", Type = "Mięso", Description = "Mięso drobiowe", Calories = 165, Carbohydrates = 0, Proteins = 31, Fats = 3.6, Price = 19.99m},
        };

        public IEnumerable<Ingredient> GetAll()
        {
            return _ingredients;
        }
    }
}
