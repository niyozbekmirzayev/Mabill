using Mabill.Data.DbContexts;
using Mabill.Data.IRepositories;
using Mabill.Data.Repositories.Base;
using Mabill.Domain.Entities.StaffsInOrganizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mabill.Data.Repositories
{
    public class StaffInOrganizationRepository : GenericRepository<StaffInOrganization>, IStaffInOrganizationRepository
    {
        public StaffInOrganizationRepository(MabillDbContext context) : base(context)
        {
        }
    }
}
