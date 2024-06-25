using CookBook.BuisnesLogic.DTO;

namespace CookBook.BuisnesLogic.Interfaces.IngredientInterfaces
{
    public interface IAddCommentService
    {
        Task AddComment(IngredientCommentDTO commentDTO);
    }
}
