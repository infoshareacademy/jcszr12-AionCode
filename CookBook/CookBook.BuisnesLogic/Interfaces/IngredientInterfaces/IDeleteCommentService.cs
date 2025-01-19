using Database.Entities;

namespace CookBook.BuisnesLogic.Interfaces.IngredientInterfaces
{
    public interface IDeleteCommentService
    {
        Task<IngredientComment> GetCommentById(int commentId);
        Task DeleteComment(int commentId);
    }
}
