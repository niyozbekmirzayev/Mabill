﻿using Mabill.Domain.Base;
using Mabill.Domain.Entities.Loanees;
using Mabill.Domain.Entities.Staffs;
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
        [NotMapped]
        public virtual Loanee Loanee { get; set; }

        [ForeignKey(nameof(GivenBy))]
        public Guid GivenById { get; set; }
        [NotMapped]
        public virtual Staff GivenBy { get; set; }

        [ForeignKey(nameof(TakeBy))]
        public Guid? TakenById { get; set; } = null;
        [NotMapped]
        public virtual Staff TakeBy { get; set; }

    }
}
