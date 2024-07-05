using CookBook.BuisnesLogic.Interfaces.RecipeInterfacces;
using Database.Entities;
using Database;
using Microsoft.EntityFrameworkCore;

namespace CookBook.BuisnesLogic.Services.RecipeCommentServices
{
    public class DeleteRecipeCommentService: IDeleteRecipeCommentService
    {
        private readonly DatabaseContext _dbContext;

        public DeleteRecipeCommentService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RecipeComment> GetCommentById(int commentId)
        {
            return await _dbContext.RecipeComments.FirstOrDefaultAsync(c => c.Id == commentId);
        }

        public async Task DeleteComment(int commentId)
        {
            var comment = await GetCommentById(commentId);
            if (comment != null)
            {
                _dbContext.RecipeComments.Remove(comment);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
