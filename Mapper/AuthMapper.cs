using AutoMapper;
using Droids.Entities.Identity;
using Droids.Models.Account;

namespace Droids.Mapper;

public class AuthMapper : Profile
{
    public AuthMapper()
    {
        CreateMap<RegisterModel, UserEntity>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email));
    }
}
