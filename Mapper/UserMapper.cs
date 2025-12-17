using AutoMapper;
using Droids.Entities;
using Droids.Models.Account;

namespace Droids.Mapper;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserItemModel, UserEntity>().ReverseMap();
        CreateMap<RegisterModel, UserEntity>()
            .ForMember(dest => dest.Avatar, opt => opt.Ignore());
    }
}
