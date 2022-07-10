using Mabill.Data.DbContexts;
using Mabill.Data.IRepositories;
using Mabill.Data.Repositories.Base;
using Mabill.Domain.Entities.LoaneesBalancesInJournals;

namespace Mabill.Data.Repositories
{
    public class LoaneeBalanceInJournalRepository : GenericRepository<LoaneeBalanceInJournal>, ILoaneeBalanceInJournalRepository
    {
        public LoaneeBalanceInJournalRepository(MabillDbContext context) : base(context)
        {
        }
    }
}
