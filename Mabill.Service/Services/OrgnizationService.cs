using Mabill.Data.IRepositories;
using Mabill.Domain.Base;
using Mabill.Domain.Entities.Organizations;
using Mabill.Domain.Enums;
using Mabill.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mabill.Service.Services
{
    public class OrgnizationService : IOrganizationService
    {
        private readonly IOrganizationRepository organizationRepository;

        public OrgnizationService(IOrganizationRepository organizationRepository)
        {
            this.organizationRepository = organizationRepository;
        }

        public Task<BaseResponse<Organization>> AddAsync(Organization organization)
        {
            var response = new BaseResponse<Organization>();

            #region Error handling
            /* if (organization == null) 
             {
                 response.Error = new BaseError(401, "Invalid data");

                 return Task.FromResult(response);
             }

             var exsistOrganization = organizationRepository.GetAsync(o => o.Status != ObjectStatus.Deleted &&
                                                                           o.Name == organization.Name);

             if(exsistOrganization != null) 
             {
                 response.Error = new BaseError(405, "Name of this organization already exsists");

                 return Task.FromResult(response);
             }*/

            throw new NotImplementedException();

            #endregion
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BaseResponse<Organization>> GetAll(Expression<Func<bool, Organization>> expression = null)
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
