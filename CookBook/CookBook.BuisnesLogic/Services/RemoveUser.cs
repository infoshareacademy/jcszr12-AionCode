using CookBook.BuisnesLogic.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.BuisnesLogic.Exceptions;

namespace CookBook.BuisnesLogic.Services
{
    public static class RemoveUser
    {
        private static bool _status = false;
        private static string path = DirectoryPathProvider.GetSolutionDirectoryInfo();
        public static bool UserDelete(int userId)
        {
            var userAllSerialise = File.ReadAllText(path);
            var users = JsonConvert.DeserializeObject<List<UserCookBook>>(userAllSerialise);
            var userToDelete = users.FirstOrDefault(r => r.Id == userId);
            if (userToDelete != null)
            {
                users.Remove(userToDelete);
                _status = true;
            }
            else
            {
                throw new ExceptionDeleteUser("Nie udało się usunąć użytkownika! Podane Id nie istnieje!");
            }
            var json = JsonConvert.SerializeObject(users);
            File.WriteAllText(path, json);
            return _status;
        }

    }
}
