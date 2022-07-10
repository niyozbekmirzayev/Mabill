using Mabill.Data.DbContexts;
using Mabill.Data.IRepositories;
using Mabill.Data.Repositories.Base;
using Mabill.Domain.Entities.StaffsInOrganizations;

namespace Mabill.Data.Repositories
{
    public class StaffInOrganizationRepository : GenericRepository<StaffInOrganization>, IStaffInOrganizationRepository
    {
        public StaffInOrganizationRepository(MabillDbContext context) : base(context)
        {
        }
    }
}
