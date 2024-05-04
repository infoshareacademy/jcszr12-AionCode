using CookBook.BuisnesLogic.Models;
using Newtonsoft.Json;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;

namespace AionCodeMVC.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private static string path = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "users.json");

        public IEnumerable<UserCookBook> GetAll()
        {
            return ReadUsersFomJson();
        }

        public UserCookBook GetByID(string id)
        {
            return ReadUsersFomJson().FirstOrDefault(x => x.Id == id);
        }

        public List<UserCookBook> ReadUsersFomJson()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            var usersAllSerialize = File.ReadAllText(path);
            var usersList = JsonConvert.DeserializeObject<List<UserCookBook>>(usersAllSerialize);
            if (usersList == null)
            {
                usersList = new List<UserCookBook>();
            }
            return usersList;
        }

        public void RegisterUser(UserCookBook user)
        {
            var users = GetAll().ToList();
            if (!users.Any(i => i.UserName == user.UserName || i.Email == user.Email))
            {
                user.Id = "sqsqsqs1";
                users.Add(user);
            }
            var json = JsonConvert.SerializeObject(users);
            File.WriteAllText(path, json);
        }

        public void DeleteUser(string id)
        {
            var users = GetAll().ToList();
            var userToDelete = users.FirstOrDefault(r => r.Id == id);
            if (userToDelete != null)
            {
                users.Remove(userToDelete);
            }
            var json = JsonConvert.SerializeObject(users);
            File.WriteAllText(path, json);

        }

        public void EditUser(UserCookBook user)
        {
            var users = GetAll().ToList();
            var userToEdit = users.FirstOrDefault(r => r.Id == user.Id);

            if (userToEdit != null)
            {
                userToEdit.UserName = user.UserName;
                userToEdit.Email = user.Email;
//                userToEdit.Password = user.Password;
//                userToEdit.Role = user.Role;
            }

            var json = JsonConvert.SerializeObject(users);
            File.WriteAllText(path, json);

        }
    }
}
