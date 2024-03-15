using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CookBook.BuisnesLogic.Exceptions;
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
        public static bool AddUser(UserCookBook newUser)
        {
            bool status = false;
            var users = GetUsersCookBook();

            if (!users.Any(i => i.Name == newUser.Name || i.Name == newUser.Email))
            {
                var number = users.Max(a => a.Id);
                newUser.Id = number + 1;
                users.Add(newUser);
                status = true;
            }
            else
            {
                throw new ExceptionAddUser();
            }

            var json = JsonConvert.SerializeObject(users);
            File.WriteAllText(path, json);
            return status;
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
