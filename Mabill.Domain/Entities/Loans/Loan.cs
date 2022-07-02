using Mabill.Domain.Base;
using Mabill.Domain.Entities.Journals;
using Mabill.Domain.Entities.Loanees;
using Mabill.Domain.Entities.Users;
using Mabill.Domain.Enums;
using Newtonsoft.Json;
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

        public Currency? CurrencyType { get; set; }

        public string CustomCurrencyType { get; set; } = null;

        [Required]
        public bool IsPaid { get; set; } = false;

        [Required]
        public DateTime Deadline { get; set; }

        [JsonIgnore]
        public Guid? LoaneeId { get; set; }
        [NotMapped]
        [ForeignKey(nameof(LoaneeId))]
        public virtual Loanee Loanee { get; set; }

        [JsonIgnore]
        public Guid? UserId { get; set; }
        [NotMapped]
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [JsonIgnore]
        public Guid GivenById { get; set; }
        [NotMapped]
        [ForeignKey(nameof(GivenById))]
        public virtual User GivenBy { get; set; }

        [JsonIgnore]
        public Guid? TakenById { get; set; }
        [NotMapped]
        [ForeignKey(nameof(TakenById))]
        public virtual User TakeBy { get; set; }

        [JsonIgnore]
        public Guid JournalId { get; set; }
        [NotMapped]
        [ForeignKey(nameof(JournalId))]
        public virtual Journal Journal { get; set; }
    }
}
