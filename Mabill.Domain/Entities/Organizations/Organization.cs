using Mabill.Domain.Base;
using Mabill.Domain.Entities.Journals;
using Mabill.Domain.Entities.Staffs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mabill.Domain.Entities.Organizations
{
    public class Organization : Auditable
    {
        public Organization()
        {
            Journals = new List<Journal>();
            Staffs = new List<Staff>();
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public decimal SumOfGivenLoans { get; set; }

        public virtual ICollection<Staff> Staffs { get; set; }
        public virtual ICollection<Journal> Journals { get; set; }
    }
}
