﻿using Mabill.Domain.Base;
using Mabill.Domain.Entities.Organizations;
using Mabill.Domain.Entities.StaffsInOrganizations;
using Mabill.Service.Dtos.Organizations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mabill.Service.Interfaces
{
    public interface IOrganizationService
    {
        BaseResponse<IEnumerable<Organization>> GetAll(Expression<Func<Organization, bool>> expression = null);
        Task<BaseResponse<Organization>> GetAsync(Expression<Func<Organization, bool>> expression);
        Task<BaseResponse<Organization>> CreateAsync(CreateOrganizationDto createOrganizationDto);
        Task<BaseResponse<bool>> DeleteAsync(DeleteOrganizationDto deleteOrganizationDto);
        Task<BaseResponse<Organization>> UpdateAysnc(UpdateOrganizationDto updateOrganizationDto);
        Task<BaseResponse<StaffInOrganization>> ChangeOwner(ChangeOrganizationOwnerDto changeOrganizationOwnerDto);
    }
}
