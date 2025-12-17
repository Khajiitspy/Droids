using AutoMapper;
using Droids.Entities;
using Droids.Models.Task;

namespace Droids.Mapper;

public class TaskMapper : Profile
{
    public TaskMapper()
    {
        CreateMap<TaskItemModel, TaskEntity>().ReverseMap();
        CreateMap<TaskCreateModel, TaskEntity>()
            .ForMember(dest => dest.Image, opt => opt.Ignore());
        CreateMap<TaskUpdateModel, TaskEntity>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Image, opt => opt.Ignore());
    }
}
 
