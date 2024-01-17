using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CookBook.BuisnesLogic.Services
{
    public class UserRegister : UserCookBook

    {
        public UserRegister()
        {
            Console.Write("Podaj nazwę: ");
            base.Name = Console.ReadLine();
            base.Email = GetEmail();
            base.Password = GetPassword();
            UserSave(Name, Email, Password);
        }

        string GetPassword()
        {
            string password = "";
            Console.Write("Podaj hasło: ");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, (password.Length - 1));
                    Console.Write("\b \b");
                }

            } while (key.Key != ConsoleKey.Enter);

            return password.GetHashCode().ToString();

        }

        string GetEmail()
        {
            Console.Write("Podaj email: ");
            string email = Console.ReadLine();
            bool isValid = IsValidEmail(email);

            static bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return true;
                }
                catch
                {
                    return false;

                }
            }
            if (isValid)
            {
                return email;
            }
            else
            {
                Console.WriteLine("Twój email jest {0}.", isValid ? email : "błędny");
                return "";
            }

        }

        void UserSave(string name, string email, string password)
        {
            string text = "";
            string path = @"usersData.txt";
            bool isThere = false;

            StreamReader sr = File.OpenText(path);
            if (File.Exists(path))
            {
                int i = 0;
                string s = "";

                while ((s = sr.ReadLine()) != null)
                {
                    List<string> userList = s.Split("/").ToList();
                    if (userList[0] == name)
                    {
                        isThere = true;
                    }
                }
                if (isThere) Console.WriteLine($"\n\nJest już użytkownik o nazwie {name}");
            }
            sr.Close();
            StreamWriter sw;

            if (!File.Exists(path))
            {
                sw = File.CreateText(path);
            }
            else
            {
                sw = new StreamWriter(path, true);
            }
            StringBuilder ddan = new StringBuilder("");
            ddan.Append(name + "/");
            ddan.Append(email + "/");
            ddan.Append(password);
            text += ddan.ToString();
            if (!isThere)
            {
                sw.WriteLine(text);
            }
            sw.Close();

            Console.WriteLine($"\n\nLista zarejestrowanych użytkowników {path} \n");
            int a = 1;
            string l = "";
            StreamReader sr2 = File.OpenText(path);
            while ((l = sr2.ReadLine()) != null)
            {
                Console.WriteLine(a++ + ". " + l);
            }
            sr2.Close();

        }
    }
}
