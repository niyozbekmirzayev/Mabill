using Mabill.Data.IRepositories.Base;
using Mabill.Domain.Entities.Journals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mabill.Data.IRepositories
{
    internal interface IJournalRepository : IGenericRepository<Journal>
    {
    }
}
