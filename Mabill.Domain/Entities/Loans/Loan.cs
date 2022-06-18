using Mabill.Domain.Base;
using Mabill.Domain.Entities.Journals;
using Mabill.Domain.Entities.Loanees;
using Mabill.Domain.Entities.Users;
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

        [Required]
        public DateTime Deadline { get; set; }

        [ForeignKey(nameof(Loanee))]
        public Guid? LoaneeId { get; set; }
        [NotMapped]
        public virtual Loanee Loanee { get; set; }

        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }
        [NotMapped]
        public virtual User User { get; set; }

        [ForeignKey(nameof(GivenBy))]
        public Guid GivenById { get; set; }
        [NotMapped]
        public virtual User GivenBy { get; set; }

        [ForeignKey(nameof(TakeBy))]
        public Guid? TakenById { get; set; }
        [NotMapped]
        public virtual User TakeBy { get; set; }

        [ForeignKey(nameof(Journal))]
        public Guid JournalId { get; set; }
        [NotMapped]
        public virtual Journal Journal { get; set; }

    }
}
