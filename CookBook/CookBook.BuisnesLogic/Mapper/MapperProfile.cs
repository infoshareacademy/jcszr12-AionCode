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

            CreateMap<CookBook.BuisnesLogic.Models.UserCookBook, UserCookBookDto>()
                .ForMember(desc => desc.Id, o => o.MapFrom(src => src.Id))
                .ForMember(desc => desc.UserName, o => o.MapFrom(src => src.UserName))
                .ForMember(desc => desc.Email, o => o.MapFrom(src => src.Email));


        }
    }
}
