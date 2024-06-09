using CookBook.BuisnesLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces
{
    public interface IAddFridgeIngredientService
    {
        Task AddFridgeIngredien(MyFridgeIngredientDTO myFridgeIngredientDTO, string ingredientName);
    }
}
