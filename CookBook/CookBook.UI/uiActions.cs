﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.BuisnesLogic.Models;
using static System.Collections.Specialized.BitVector32;

namespace CookBook.UI
{
    internal class UiActions
    {
        public static void ActionRun(ref string action, ref Roles role)
        {
            switch (action)
            {
                case "loginmenu":
                    (action, role) = LoginMenu.Login();
                    break;
                case "stdusermenu":
                    action = StdUserMenu.Display();
                    break;
                case "adminmenu":
                    action = AdminMenu.Display();
                    break;
                case "guestmenu":
                    role = Roles.Guest;
                    action = GuestMenu.Display();
                    break;
                case "mainmenu":
                    action = MainMenu.Display();
                    break;
                case "recipelist":
                    RecipeMenu.ShowRecipe();
                    if (role == Roles.Guest) action = "guestmenu"; else action = "stdusermenu";
                    break;
                case "recipeadd":
                    RecipeMenu.RecipeAdd();
                    if (role == Roles.Guest) action = "guestmenu"; else action = "stdusermenu";
                    break;
                case "userlist":
                    LoginMenu.ShowUsersList();
                    action = "adminmenu";
                    break;
                case "registermenu":
                    action = LoginMenu.NewUserRegister();
                    break;
                case "userremove":
                    LoginMenu.UserRemove();
                    action = "adminmenu";
                    break;
                case "reciperemove":
                    RecipeMenu.RecipeRemove();
                    if (role == Roles.Guest) action = "guestmenu"; else action = "stdusermenu";
                    break;
            }
        }
    }
}
