using API.ApiModels;
using AutoMapper;
using AutoMapper.Mappers;
using Domain.ToDo.Entity;

namespace API.Mappers
{
    public class ToDoMapper : Profile
    {
        public ToDoMapper()
        {
            CreateMap<ToDoResponseModel, ToDo>();
            CreateMap<ToDo, ToDoResponseModel>();
            CreateMap<ToDoDTO, ToDo>();
        }
    }
}