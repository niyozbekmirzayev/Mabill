using Mabill.Data.DbContexts;
using Mabill.Data.IRepositories;
using Mabill.Data.Repositories.Base;
using Mabill.Domain.Entities.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mabill.Data.Repositories
{
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        public LoanRepository(MabillDbContext context) : base(context)
        {
        }
    }
}
