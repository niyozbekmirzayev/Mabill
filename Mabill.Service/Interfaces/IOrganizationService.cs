using Mabill.Domain.Base;
using Mabill.Domain.Entities.Organizations;
using Mabill.Service.Dtos.Organizations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mabill.Service.Interfaces
{
    public interface IOrganizationService
    {
        BaseResponse<IEnumerable<Organization>> GetAll(Expression<Func<bool, Organization>> expression = null);
        Task<BaseResponse<Organization>> GetAsync(Expression<Func<bool, Organization>> expression);
        Task<BaseResponse<Organization>> CreateAsync(CreateOrganizationDto organization);
        Task<BaseResponse<Organization>> UpdateAysnc(Organization organization);
        Task<bool> DeleteAsync(Guid id);
    }
}
