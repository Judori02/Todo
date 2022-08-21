using AutoMapper;
using Todo.Web.Data.Entities;
using Todo.Web.Models;

namespace Todo.Web.Infrastructure.Mappers
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<ToDoItem, ToDoItemViewModel>().ReverseMap();
        }
    }
}
