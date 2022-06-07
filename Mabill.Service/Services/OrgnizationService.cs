using Mabill.Data.IRepositories;
using Mabill.Domain.Entities.Organizations;
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

        public Task<Organization> AddAsync(Organization organization)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Organization> GetAll(Expression<Func<bool, Organization>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> GetAsync(Expression<Func<bool, Organization>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> UpdateAysnc(Organization organization)
        {
            throw new NotImplementedException();
        }
    }
}
