using Mabill.Domain.Base;
using Mabill.Domain.Entities.LoaneesBalancesInJournals;
using Mabill.Domain.Entities.Loans;
using Mabill.Domain.Entities.StaffsInOrganizations;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mabill.Domain.Entities.Users
{
    public class User : Person
    {
        public User()
        {
            Loans = new List<Loan>();
            Occupations = new List<StaffInOrganization>();
            BalanceInJournals = new List<LoaneeBalanceInJournal>();
        }

        #region Common
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        #endregion

        public virtual ICollection<StaffInOrganization> Occupations { get; set; }

        #region Loanee
        public virtual ICollection<LoaneeBalanceInJournal> BalanceInJournals { get; set; }

        [NotMapped]
        public decimal SumOfLoansBetweenSpecificTime { get; set; }
        [NotMapped]
        public decimal SumOfRepaidLoansBeetweenSpecificTime { get; set; }

        [InverseProperty(nameof(Loan.User))]
        public virtual ICollection<Loan> Loans { get; set; }
        #endregion
    }
}
