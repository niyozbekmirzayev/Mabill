using Mabill.Data.DbContexts;
using Mabill.Data.IRepositories;
using Mabill.Data.Repositories.Base;
using Mabill.Domain.Entities.Loanees;

namespace Mabill.Data.Repositories
{
    public class LoaneeRepository : GenericRepository<Loanee>, ILoaneeRepository
    {
        public LoaneeRepository(MabillDbContext context) : base(context)
        {
        }
    }
}
