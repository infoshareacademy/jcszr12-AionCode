using CookBook.BuisnesLogic.DTO;
using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Interfaces.MyFridgeInterfaces
{
    public interface IGetMyFridgeService
    {
        Task<IEnumerable<MyFridgeDTO>> GetAllMyFridges();
    }
}
