using Mabill.Domain.Base;
using Mabill.Domain.Entities.Loanees;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mabill.Domain.Entities.Loans
{
    public class Loan : Auditable
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime Deadline { get; set; }
        [ForeignKey(nameof(Loanee))]
        public Guid LoaneeId { get; set; }
        public Loanee Loanee { get; set; }
    }
}
