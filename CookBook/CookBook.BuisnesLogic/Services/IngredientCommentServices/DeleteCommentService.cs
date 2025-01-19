using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BuisnesLogic.Services.IngredientCommentServices
{
    public class DeleteCommentService : IDeleteCommentService
    {
        private readonly DatabaseContext _dbContext;

        public DeleteCommentService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IngredientComment> GetCommentById(int commentId)
        {
            return await _dbContext.IngredientComment.FirstOrDefaultAsync(c => c.Id == commentId);
        }

        public async Task DeleteComment(int commentId)
        {
            var comment = await GetCommentById(commentId);
            if (comment != null)
            {
                _dbContext.IngredientComment.Remove(comment);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
