using Mabill.Domain.Base;
using Mabill.Domain.Entities.Loanees;
using Mabill.Domain.Entities.Loans;
using Mabill.Domain.Entities.Organizations;
using Newtonsoft.Json;
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
        [NotMapped]
        public decimal SumOfGivenLoans { get; set; }

        [JsonIgnore]
        public Guid OrganizationId { get; set; }

        [ForeignKey(nameof(OrganizationId))]
        public virtual Organization Organization { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
        public virtual ICollection<Loanee> Loanees { get; set; }
    }
}
