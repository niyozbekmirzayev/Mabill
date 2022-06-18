using Mabill.Domain.Base;
using Mabill.Domain.Entities.Journals;
using Mabill.Domain.Entities.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mabill.Domain.Entities.Organizations
{
    public class Organization : Auditable
    {
        public Organization()
        {
            Journals = new List<Journal>();
            Staffs = new List<User>();
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public decimal SumOfGivenLoans { get; set; }

        public virtual ICollection<User> Staffs { get; set; }
        public virtual ICollection<Journal> Journals { get; set; }
    }
}
