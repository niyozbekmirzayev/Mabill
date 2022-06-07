using Mabill.Domain.Entities.Organizations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mabill.Service.Interfaces
{
    public interface IOrganizationService
    {
        IEnumerable<Organization> GetAll(Expression<Func<bool, Organization>> expression = null);
        Task<Organization> GetAsync(Expression<Func<bool, Organization>> expression);
        Task<Organization> AddAsync(Organization organization);
        Task<Organization> UpdateAysnc(Organization organization);
        Task<bool> DeleteAsync(Guid id);
    }
}
