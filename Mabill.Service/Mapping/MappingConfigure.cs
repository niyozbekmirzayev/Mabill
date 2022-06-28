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
            CreateMap<CreateOrganizationDto, Organization>().ReverseMap();

            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<User, UpdateUserPasswordDto>();
            CreateMap<UpdateUserProfileDto, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
