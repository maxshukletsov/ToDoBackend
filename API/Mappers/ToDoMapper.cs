using API.ApiModels;
using AutoMapper;
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
            CreateMap<ToDo, ToDo>()
                .ForMember(
                    todo => todo.Id, 
                    opt => opt.Ignore());
        }
    }
}