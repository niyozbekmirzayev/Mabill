using Mabill.Data.DbContexts;
using Mabill.Data.IRepositories;
using Mabill.Data.Repositories.Base;
using Mabill.Domain.Entities.Loanees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mabill.Data.Repositories
{
    public class LoaneeRepository : GenericRepository<Loanee>, ILoaneeRepository
    {
        public LoaneeRepository(MabillDbContext context) : base(context)
        {
        }
    }
}
