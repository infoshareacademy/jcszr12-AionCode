using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Database.SampleData
{
    public static class SampleData
    {
        public static List<IngredientDetails> GetIngredientDetailsSampleDataFromJson()
        {

            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // Połącz ścieżkę katalogu z nazwą pliku
            string filePath = Path.Combine(basePath, "IngredientDetailsSeed-data.json");

            // Odczytaj zawartość pliku
            string seedData = File.ReadAllText(filePath);


            return JsonConvert.DeserializeObject<List<IngredientDetails>>(seedData);

            // Seed data from JSON file
        }        
        public static List<UserCookBook> GetUserCookBookSampleDataFromJson()
        {

            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            // Połącz ścieżkę katalogu z nazwą pliku
            string filePath = Path.Combine(basePath, "UserCookBookSeed-data.json");

            // Odczytaj zawartość pliku
            string seedData = File.ReadAllText(filePath);


            return JsonConvert.DeserializeObject<List<UserCookBook>>(seedData);

            // Seed data from JSON file
        }




    }
}
