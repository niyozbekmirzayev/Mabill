using Mabill.Domain.Base;
using Mabill.Domain.Entities.Organizations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mabill.Domain.Entities.Journals
{
    public class Journal : Auditable
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        public decimal SumOfGivenLoans { get; set; }

        [ForeignKey(nameof(Organization))]
        public Guid OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
