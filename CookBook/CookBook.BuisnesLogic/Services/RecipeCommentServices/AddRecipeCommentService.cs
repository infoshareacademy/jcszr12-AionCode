using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.RecipeInterfacces;
using Database.Entities;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Services.RecipeCommentServices
{
    public class AddRecipeCommentService : IAddRecipeCommentService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        public AddRecipeCommentService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task AddComment(RecipeCommentDTO commentDTO)
        {
            var comment = _mapper.Map<RecipeComment>(commentDTO);
            _dbContext.RecipeComments.Add(comment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
