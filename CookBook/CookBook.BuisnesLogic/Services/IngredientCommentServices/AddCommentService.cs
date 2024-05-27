using CookBook.BuisnesLogic.Interfaces.IngredientInterfaces;
using Database.Entities;
using Database;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CookBook.BuisnesLogic.DTO;

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
