using Mabill.Domain.Base;
using Mabill.Domain.Entities.Organizations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mabill.Domain.Entities.Journals
{
    public class Journal : Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal SumOfGivenLoans { get; set; }
        [ForeignKey(nameof(Organization))]
        public Guid OrganizaitonId { get; set; }
        public Organization Organization { get; set; }
    }
}
