using Mabill.Domain.Entities.Admins;
using Mabill.Domain.Entities.Journals;
using Mabill.Domain.Entities.Loanees;
using Mabill.Domain.Entities.Loans;
using Mabill.Domain.Entities.Organizations;
using Microsoft.EntityFrameworkCore;

namespace Mabill.Data.DbContexts
{
    public class MabillDbContext : DbContext
    {
        public MabillDbContext(DbContextOptions<MabillDbContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Loanee> Loanees { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}
