﻿using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using CookBook.BuisnesLogic.Interfaces.UserInterfaces;
using CookBook.BuisnesLogic.Models;
using Database;
using Database.Entities;
using Database.EnumTypes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Web.Mvc;

namespace CookBook.BuisnesLogic.Services.UserServices
{
    public class GetUserService : IGetUserService
    {
        private IUsersRepository _repository;
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<Database.Entities.UserCookBook> _userManager;
        
        public GetUserService(IUsersRepository repository, DatabaseContext dbContext, IMapper mapper, UserManager<Database.Entities.UserCookBook> userManager)
        {
            _repository = repository;
            _dbContext = dbContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<UserCookBookDto>> GetAll()
        {
            List<Database.Entities.UserCookBook> usersDb = await _dbContext.Users.OrderBy(user => user.UserName).ToListAsync();

            var users = new List<UserCookBookDto>();
            foreach (var user in usersDb)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.FirstOrDefault();

                var userToAdd = new UserCookBookDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = string.Empty,
                    Role = (Roles)Enum.Parse(typeof(Roles), role),
                    AddDate = user.AddDate
                };
                users.Add(userToAdd);
            }
                return users;
        }

        public async Task<UserCookBookDto> GetByID(string id)
        {
            Database.Entities.UserCookBook userDb = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

                var roles = await _userManager.GetRolesAsync(userDb);
                var role = roles.FirstOrDefault();

                var user = new UserCookBookDto
                {
                    Id = userDb.Id,
                    UserName = userDb.UserName,
                    Email = userDb.Email,
                    Password = string.Empty,
                    Role = (Roles)Enum.Parse(typeof(Roles), role),
                    AddDate = userDb.AddDate
                };
        return user;
        }
    }
}
