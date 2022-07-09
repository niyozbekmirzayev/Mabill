using Mabill.Domain.Base;
using Mabill.Domain.Entities.LoaneesBalancesInJournals;
using Mabill.Domain.Entities.Loans;
using Mabill.Domain.Entities.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mabill.Domain.Entities.Loanees
{
    public class Loanee : Person
    {
        public Loanee()
        {
            Loans = new List<Loan>();
            BalanceInJournals = new List<LoaneeBalanceInJournal>();
        }

        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<LoaneeBalanceInJournal> BalanceInJournals { get; set; }

        public string Description { get; set; }
        [NotMapped]
        public decimal SumOfLoansBetweenSpecificTime { get; set; }
        [NotMapped]
        public decimal SumOfRepaidLoansBeetweenSpecificTime { get; set; }

        [JsonIgnore]
        public Guid AddedById { get; set; }

        [ForeignKey(nameof(AddedById))]
        public virtual User AddedBy { get; set; }
    }
}
