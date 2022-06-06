using Mabill.Data.DbContexts;
using Mabill.Data.IRepositories;
using Mabill.Data.Repositories.Base;
using Mabill.Domain.Entities.Journals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mabill.Data.Repositories
{
    public class JournalRepository : GenericRepository<Journal>, IJournalRepository
    {
        public JournalRepository(MabillDbContext context) : base(context)
        {
        }
    }
}
