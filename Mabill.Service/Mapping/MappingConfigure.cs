using AutoMapper;
using Mabill.Domain.Entities.Organizations;
using Mabill.Domain.Entities.Users;
using Mabill.Service.Dtos.Organizations;
using Mabill.Service.Dtos.Users;

namespace Mabill.Service.Mapping
{
    public class MappingConfigure : Profile
    {
        public MappingConfigure()
        {
            CreateMap<Organization, GetOrganizationDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserPasswordDto>().ReverseMap();
            CreateMap<User, UpdateUserProfileDto>().ReverseMap();
        }
    }
}
