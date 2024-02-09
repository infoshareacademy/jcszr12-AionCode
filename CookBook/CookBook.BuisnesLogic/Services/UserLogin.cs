using CookBook.BuisnesLogic.Exceptions;
using CookBook.BuisnesLogic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Services
{
    public static class UserLogin //Andrzej
    {
        private static string _login; 
        private static string _password;

        
            
        
        private static string path = DirectoryPathProvider.GetSolutionDirectoryInfo();
        public static UserCookBook LoginUser(string Name, string Password)
        {
            _login = Name;
            _password = Password;
            var userAllSerialise = File.ReadAllText(path);
            var users = JsonConvert.DeserializeObject<List<UserCookBook>>(userAllSerialise);
            var user = users.Where(u => u.Name == _login && u.Password == _password).FirstOrDefault();
            
            if (user == null)
            {
                throw new ExceptionLogin("Błąd:");
            }

            return user;
        }
    }
}
