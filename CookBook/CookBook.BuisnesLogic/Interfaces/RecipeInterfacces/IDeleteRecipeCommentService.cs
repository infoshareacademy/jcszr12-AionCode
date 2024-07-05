using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Interfaces.RecipeInterfacces
{
    public interface IDeleteRecipeCommentService
    {
        Task<RecipeComment> GetCommentById(int commentId);
        Task DeleteComment(int commentId);
    }
}
