using AutoMapper;
using Kochbuch_Backend.Data;
using Kochbuch_Backend.Models.Ingredient;
using Kochbuch_Backend.Models.Reciepe;
using Kochbuch_Backend.Models.User;

namespace Kochbuch_Backend.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Reciepe, CreateReciepeDto>().ReverseMap();
            CreateMap<Reciepe, GetReciepeDto>().ReverseMap();
            CreateMap<Reciepe, ReciepeDetailsDto>().ReverseMap();
            CreateMap<Reciepe, UpdateReciepeDto>().ReverseMap();

            CreateMap<Ingredient, CreateReciepeDto>().ReverseMap();
            CreateMap<Ingredient, UpdateIngredientDto>().ReverseMap();
            CreateMap<Ingredient, IngredientDto>().ReverseMap();

            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
