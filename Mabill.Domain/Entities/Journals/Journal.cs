using Mabill.Domain.Base;
using Mabill.Domain.Entities.Loanees;
using Mabill.Domain.Entities.Loans;
using Mabill.Domain.Entities.Organizations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mabill.Domain.Entities.Journals
{
    public class Journal : Auditable
    {
        public Journal()
        {
            Loans = new List<Loan>();
            Loanees = new List<Loanee>();
        }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal SumOfGivenLoans { get; set; }

        [ForeignKey(nameof(Organization))]
        public Guid OrganizationId { get; set; }
        [NotMapped]
        public virtual Organization Organization { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Loanee> Loanees { get; set; }
    }
}
