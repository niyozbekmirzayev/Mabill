using Mabill.Data.IRepositories.Base;
using Mabill.Domain.Entities.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mabill.Data.IRepositories
{
    public interface ILoanRepository : IGenericRepository<Loan>
    {
    }
}
