using Mabill.Domain.Base;
using Mabill.Domain.Entities.Admins;
using Mabill.Domain.Entities.Journals;
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
            Admins = new List<Admin>();
        }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public decimal SumOfGivenLoans { get; set; }
        
        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Journal> Journals { get; set; }

        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }
        public virtual Admin Owner { get; set; }
    }
}
