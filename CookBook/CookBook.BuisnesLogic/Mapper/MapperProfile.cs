using AutoMapper;
using CookBook.BuisnesLogic.DTO;
using Database.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BuisnesLogic.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<IngredientDetails, IngredientDTO>().ReverseMap();
            CreateMap<IngredientDetails, IngredientDetailedDTO>().ReverseMap();
            CreateMap<IngredientDetails, IngredientEditDTO>().ReverseMap();

            CreateMap<RecipeDetails, RecipeDTO>().ReverseMap();
            CreateMap<RecipeDetails, RecipeDetailsDTO>().ReverseMap();
            CreateMap<RecipeDetails, RecipeEditDTO>().ReverseMap();

            CreateMap<MyFridgeIngredient, MyFridgeIngredientDTO>().ReverseMap();
            CreateMap<MyFridge, MyFridgeDTO>().ReverseMap();

            CreateMap<IngredientCommentDTO, IngredientComment>().ReverseMap();

            CreateMap<UserCookBook, UserCookBookDto>();
            CreateMap<UserCookBookDto, ChangePasswordDto>();
        }
    }
}
