using AutoMapper;
using Mabill.Data.IRepositories;
using Mabill.Domain.Base;
using Mabill.Domain.Entities.Organizations;
using Mabill.Domain.Enums;
using Mabill.Service.Dtos.Organizations;
using Mabill.Service.Helpers;
using Mabill.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mabill.Service.Services
{
    public class OrgnizationService : IOrganizationService
    {
        private readonly IMapper mapper;
        private IOrganizationRepository organizationRepository;
        private IUserRepository userRepository;
        private HttpContextHelper httpContextHelper;

        public OrgnizationService(IOrganizationRepository IOrganizationRepository,
            IMapper mapper, IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository)
        {
            this.httpContextHelper = new HttpContextHelper(httpContextAccessor);
            this.organizationRepository = IOrganizationRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<BaseResponse<Organization>> CreateAsync(CreateOrganizationDto organization)
        {
            var response = new BaseResponse<Organization>();

            #region Date validation
            if (organization == null)
            {
                response.Error = new BaseError(401, "Invalid data");

                return response;
            }

            var exsistOrganization = await organizationRepository.GetAsync(o => o.Status != ObjectStatus.Deleted &&
                                                                          o.Name == organization.Name);

            if (exsistOrganization != null)
            {
                response.Error = new BaseError(405, "Name of this organization already exsists");

                return response;
            }
            #endregion

            var currentUser = httpContextHelper.GetCurrentUser();
            var mappedOrganization = mapper.Map<Organization>(organization);

            var owner = await userRepository.GetAsync(p => p.Id == currentUser.Id);
            owner.Role = StaffRole.Owner;

            mappedOrganization.Create(currentUser.Id);
            var createdOrganization = await organizationRepository.CreateAsync(mappedOrganization);
            createdOrganization.Staffs.Add(owner);
            
            await organizationRepository.SaveChangesAsync();
            response.Data = createdOrganization;

            return response;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public BaseResponse<IEnumerable<Organization>> GetAll(Expression<Func<bool, Organization>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Organization>> GetAsync(Expression<Func<bool, Organization>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<Organization>> UpdateAysnc(Organization organization)
        {
            throw new NotImplementedException();
        }
    }
}
