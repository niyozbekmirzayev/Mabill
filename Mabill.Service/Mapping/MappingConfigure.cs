using AutoMapper;
using Mabill.Domain.Entities.Organizations;
using Mabill.Service.Dtos.Organizations;

namespace Mabill.Service.Mapping
{
    public class MappingConfigure : Profile
    {
        public MappingConfigure()
        {
            CreateMap<Organization, GetOrganizationDto>().ReverseMap();
        }
    }
}
