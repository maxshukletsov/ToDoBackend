using API.ApiModels;
using AutoMapper;
using Domain.User.Entity;

namespace API.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserResponseModel, User>();
            CreateMap<User, UserResponseModel>();
        }
    }
}