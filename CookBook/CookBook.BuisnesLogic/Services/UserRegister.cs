using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CookBook.BuisnesLogic.Models;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace CookBook.BuisnesLogic.Services
{
    public static class UserRegister

    {
            private static string path = DirectoryPathProvider.GetSolutionDirectoryInfo();
            public static List<UserCookBook> GetUsersCookBook()
            {
                CreateDataFile();
                var userAllSerialise = File.ReadAllText(path);
                var users = JsonConvert.DeserializeObject<List<UserCookBook>>(userAllSerialise);
                if (users == null)
                {
                    users = new List<UserCookBook>();
                }
                    return users;
            }
            public static void AddUser(UserCookBook newUser)
            {
                
                var users = GetUsersCookBook();
                newUser.Id = users.Count() + 1;
                users.Add(newUser);

                var json = JsonConvert.SerializeObject(users);
                File.WriteAllText(path, json);
        }
        private static void CreateDataFile()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
        }

    }
}
