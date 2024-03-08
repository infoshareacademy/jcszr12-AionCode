﻿using CookBook.BuisnesLogic.Models;

namespace CookBook.BuisnesLogic.Services
{
    public interface IRecipeService
    {
        IEnumerable<Recipe> GetAll();   //Do zmiany
        Recipe GetById(int id);
        bool DeleteById(int id);
        Recipe Create(Recipe newRecipe);
        bool Update(int id, Recipe recipe);
        
    }
}
