using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Interfaces.IngredientInterfaces
{
    public interface IDeleteCommentService
    {
        Task<IngredientComment> GetCommentById(int commentId);
        Task DeleteComment(int commentId);
    }
}
