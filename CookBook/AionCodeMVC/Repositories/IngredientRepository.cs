using AionCodeMVC.Interfaces;
using AionCodeMVC.Models;
using Newtonsoft.Json;
using System.IO;

namespace AionCodeMVC.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        public IEnumerable<Ingredient> GetAll()
        {
            return ReadIngredientsFomJson();
        }
        public Ingredient GetByID(int id)
        {
            return ReadIngredientsFomJson().FirstOrDefault(x=> x.Id == id);
        }

        private static string path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "ingredients.json");
        private static List<Ingredient> ReadIngredientsFomJson()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            var ingredientAllSerialize = File.ReadAllText(path);
            var ingredientList = JsonConvert.DeserializeObject<List<Ingredient>>(ingredientAllSerialize);
            if (ingredientList == null)
            {
                ingredientList = new List<Ingredient>();
            }
            return ingredientList;
        }
    }
}
