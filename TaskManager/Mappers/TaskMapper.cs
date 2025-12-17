using AutoMapper;
using TaskManager.DTO;

namespace TaskManager.Mappers
{
    public class TaskMapper : Profile
    {
        public TaskMapper()
        {
            CreateMap<Entities.Task,TaskDto>().ReverseMap();
            CreateMap<Entities.Task,TaskUpdateDto>().ReverseMap();
            CreateMap<Entities.Task,TaskInsertDto>().ReverseMap();
        }
    }
}
