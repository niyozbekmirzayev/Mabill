using Mabill.Domain.Base;
using Mabill.Domain.Entities.Admins;
using Mabill.Domain.Entities.Loanees;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mabill.Domain.Entities.Loans
{
    public class Loan : Auditable
    {
        public string Description { get; set; }
        
        [Required]
        public decimal Amount { get; set; }
        
        [Required]
        public bool IsPaid { get; set; } = false;
        
        public DateTime Deadline { get; set; }
        
        [ForeignKey(nameof(Loanee))]
        public Guid LoaneeId { get; set; }
        public virtual Loanee Loanee { get; set; }
        
        [ForeignKey(nameof(GivenBy))]
        public Guid GivenById { get; set; }
        public virtual Admin GivenBy { get; set; }

        [ForeignKey(nameof(TakeBy))]
        public Guid? TakenById { get; set; } = null;
        public virtual Admin TakeBy { get; set; }
       
    }
}
