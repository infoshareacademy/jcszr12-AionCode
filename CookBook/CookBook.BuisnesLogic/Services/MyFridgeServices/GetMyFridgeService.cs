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
using System.Runtime.InteropServices;

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

        public async Task<List<Tuple<RecipeDTO, List<string>, List<string>>>> GetProposedRecipes(IEnumerable<MyFridgeDTO> myFridges)
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

            var recipeIdplusOwnedIngredients = new Dictionary<int, List<int>>(); //<- lista (1, (1,2,3,4) idprzepisu id skladnikow ktore mamy

            // Populate the dictionary
            foreach (var pair in pairs)
            {
                if (!recipeIdplusOwnedIngredients.ContainsKey(pair.Item1))
                {
                    recipeIdplusOwnedIngredients[pair.Item1] = new List<int>();
                }
                recipeIdplusOwnedIngredients[pair.Item1].Add(pair.Item2);
            }

            var keys = recipeIdplusOwnedIngredients.Keys.ToList();


            var recipeIdplusNeededIngredients = new Dictionary<int, List<int>>(); //<- lista (1, (1,2,3,4) idprzepisu id skladnikow ktore sa potrzebne do wykonania na 100 %

            foreach (var key in keys)
            {
                var recipeDetailsIDList = await _dbContext.IngredientUsed.Where(r => r.RecipeDetails.Id == key).Select(x=>x.IngredientDetailsId).ToListAsync();

                if (recipeDetailsIDList.Count>0)
                {
                    List<int> resultList = recipeDetailsIDList.Where(i => i.HasValue).Select(i => i.Value).ToList();
                    recipeIdplusNeededIngredients[key] = resultList;
                }
            }


            // Pobierz rekordy z bazy danych pasujące do kluczy
            var recipesList = await _dbContext.RecipeDetails
                                            .Where(recipe => keys.Contains(recipe.Id))
                                            .ToListAsync();
            var recipeListDTO = _mapper.Map<List<RecipeDTO>>(recipesList);



            var smth = new List<Tuple<RecipeDTO, List<string>, List<string>>>();

            foreach (var recipeDTO in recipeListDTO)
            {
                if (recipeIdplusOwnedIngredients.TryGetValue(recipeDTO.Id, out var ownedIngredients) &&
                    recipeIdplusNeededIngredients.TryGetValue(recipeDTO.Id, out var neededIngredients))
                {
                    // Pobierz nazwy składników na podstawie ich ID
                    var ownedIngredientNames = new List<string>();
                    var neededIngredientNames = new List<string>();

                    // Pobierz nazwy składników dla ownedIngredients
                    foreach (var ownedIngredientId in ownedIngredients)
                    {
                        var ingredientName = await _dbContext.IngredientDetails
                                                              .Where(i => i.Id == ownedIngredientId)
                                                              .Select(i => i.Name)
                                                              .FirstOrDefaultAsync();

                        if (!string.IsNullOrEmpty(ingredientName))
                        {
                            ownedIngredientNames.Add(ingredientName);
                        }
                    }

                    // Pobierz nazwy składników dla neededIngredients
                    foreach (var neededIngredientId in neededIngredients)
                    {
                        var ingredientName = await _dbContext.IngredientDetails
                                                              .Where(i => i.Id == neededIngredientId)
                                                              .Select(i => i.Name)
                                                              .FirstOrDefaultAsync();

                        if (!string.IsNullOrEmpty(ingredientName))
                        {
                            neededIngredientNames.Add(ingredientName);
                        }
                    }

                    // Dodaj tuplę z nazwami składników do listy smth
                    smth.Add(new Tuple<RecipeDTO, List<string>, List<string>>(recipeDTO, ownedIngredientNames, neededIngredientNames));
                }
            }

            return smth;
        }


    }
}
