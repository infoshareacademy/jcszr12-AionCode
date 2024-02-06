using CookBook.BuisnesLogic.Models;
using CookBook.BuisnesLogic.Services;
using CookBook.BuisnesLogic.TempTestUI;
using CookBook.UI.TempTest;

namespace CookBook.BuisnesLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var NewUser = new UserCookBook()
            {
                Id = 0,
                Name = FormsAddUser.GetName(),
                Email = FormsAddUser.GetEmail(),
                Password = FormsAddUser.GetPassword(),
                Role = Roles.Admin
            };
            if (!UserRegister.AddUser(NewUser)) Console.WriteLine("\nJest już taki użytkownik!");

            FormsAddUser.ShowAllUsers(UserRegister.GetUsersCookBook());

        }

















        /*TEST FOR ADDING RECIPE*/

        //static void Main(string[] args)
        //{
        //    var NewRecipe = new Recipe()
        //    {
        //        Id = 0,
        //        Name = AddedRecipeTest.GetName(),
        //        Category = AddedRecipeTest.GetCategory(),
        //        Description = AddedRecipeTest.GetDescription(),
        //        IngredientList = AddedRecipeTest.GetIngredientList()

        //    };
        //    if (!AddRecipe.RecipeAdd(NewRecipe)) Console.WriteLine("\nJest już taki przepis");

        //    AddedRecipeTest.ShowAllRecipe(AddRecipe.GetRecipe());

        //}
    }
}
