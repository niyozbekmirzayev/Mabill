using Mabill.Domain.Base;
using Mabill.Domain.Entities.Journals;
using Mabill.Domain.Entities.StaffsInOrganizations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mabill.Domain.Entities.Organizations
{
    public class Organization : Auditable
    {
        public Organization()
        {
            Journals = new List<Journal>();
            Staffs = new List<StaffInOrganization>();
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public string Description { get; set; }
        public decimal SumOfGivenLoans { get; set; }
        public virtual ICollection<Journal> Journals { get; set; }
        public virtual ICollection<StaffInOrganization> Staffs { get; set; }
    }
}
