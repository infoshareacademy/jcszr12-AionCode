using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using Database;
using Database.Entities;

namespace CookBook.BuisnesLogic.Services.IngredientCommentServices
{
    public class AddCommentService : IAddCommentService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public AddCommentService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddComment(IngredientCommentDTO commentDTO)
        {
            var comment = _mapper.Map<IngredientComment>(commentDTO);

            // Możesz tutaj również wykonać inne operacje na komentarzu przed dodaniem do bazy danych, jeśli jest to konieczne

            _dbContext.IngredientComment.Add(comment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
