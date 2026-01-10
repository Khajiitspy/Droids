using AutoMapper;
using Droids.Entities.Identity;
using Droids.Models.Account;
using Droids.Models.Seeder;

namespace Droids.Mapper;

public class AuthMapper : Profile
{
    public AuthMapper()
    {
        CreateMap<RegisterModel, UserEntity>()
            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email));
        CreateMap<SeederUserModel, UserEntity>()
            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email));
    }
}
