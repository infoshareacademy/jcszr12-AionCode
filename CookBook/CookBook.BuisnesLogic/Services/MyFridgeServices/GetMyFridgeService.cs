using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using Database.Entities;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces;

namespace CookBook.BuisnesLogic.Services.MyFridgeServices
{
    public class GetMyFridgeService : IGetMyFridgeService
    {

        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IGetUserService _getUserService;

        public GetMyFridgeService(DatabaseContext dbContext, IMapper mapper, IGetUserService userService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _getUserService = userService;
        }

        public async Task<IEnumerable<MyFridgeDTO>> GetAllMyFridges()
        {
            string userId = await _getUserService.LoggedUserIdAsync();


            var myFridges = await _dbContext.MyFridge
                   .Include(f => f.MyFridgeIngredients).ThenInclude(f => f.IngredientDetails) // Załaduj IngredientDetails
                   .Where(f => f.UserCookBook.Id == userId) // Filtruj lodówki dla zalogowanego użytkownika
                   .ToListAsync();

            var myFridgeDTOs = _mapper.Map<IEnumerable<MyFridge>, IEnumerable<MyFridgeDTO>>(myFridges);

            return myFridgeDTOs;
        }

        public async Task<IEnumerable<RecipeDTO>> GetProposedRecipes(IEnumerable<MyFridgeDTO> myFridges)
        {
            //stworz liste ingredientdetailsid z ingridientow z lodowek myfridegs
            var fridgeIngredientsDetailsIDs = new List<int>();

            foreach (var frige in myFridges)
            {
                foreach (var fridgeIngredient in frige.MyFridgeIngredients)
                {
                    fridgeIngredientsDetailsIDs.Add(fridgeIngredient.IngredientDetailsId);
                }
            }

            var pairs = new List<(int, int)>();

            foreach (var item in fridgeIngredientsDetailsIDs)
            {
                var recipeDetailsIDList = await _dbContext.IngredientUsed.Where(r=>r.IngredientDetailsId == item).Select(p=>p.RecipeDetailsId).ToListAsync();
                if (recipeDetailsIDList.Count>0 && recipeDetailsIDList!=null)
                {
                    foreach (var recipeDetailID in recipeDetailsIDList)
                    {
                        pairs.Add(((int)recipeDetailID, item));
                    }
                }
            }

            //dla kazdego ingridienta utworz pare  recipeDetails id / ingredient detaislid (1,1) (1,2) z tabeli recipe used

            var sortedPairs = new Dictionary<int, List<int>>();

            // Populate the dictionary
            foreach (var pair in pairs)
            {
                if (!sortedPairs.ContainsKey(pair.Item1))
                {
                    sortedPairs[pair.Item1] = new List<int>();
                }
                sortedPairs[pair.Item1].Add(pair.Item2);
            }

            var keys = sortedPairs.Keys.ToList();

            // Pobierz rekordy z bazy danych pasujące do kluczy
            var recipesList = await _dbContext.RecipeDetails
                                            .Where(recipe => keys.Contains(recipe.Id))
                                            .ToListAsync();
            var recipeListDTO = _mapper.Map<List<RecipeDTO>>(recipesList);

            return recipeListDTO;


        }


    }
}
