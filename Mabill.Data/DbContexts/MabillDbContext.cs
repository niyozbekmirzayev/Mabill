using Mabill.Domain.Entities.Journals;
using Mabill.Domain.Entities.Loanees;
using Mabill.Domain.Entities.Loans;
using Mabill.Domain.Entities.Organizations;
using Mabill.Domain.Entities.Staffs;
using Microsoft.EntityFrameworkCore;

namespace Mabill.Data.DbContexts
{
    public class MabillDbContext : DbContext
    {
        public MabillDbContext(DbContextOptions<MabillDbContext> options) : base(options)
        {
        }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Loanee> Loanees { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}
