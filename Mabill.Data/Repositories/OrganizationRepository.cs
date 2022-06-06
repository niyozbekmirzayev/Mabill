using Mabill.Data.DbContexts;
using Mabill.Data.IRepositories;
using Mabill.Data.IRepositories.Base;
using Mabill.Data.Repositories.Base;
using Mabill.Domain.Entities.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mabill.Data.Repositories
{
    public class OrganizationRepository : GenericRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(MabillDbContext context) : base(context)
        {
        }
    }
}
