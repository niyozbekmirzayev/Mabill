using Mabill.Domain.Base;
using Mabill.Domain.Entities.Admins;
using Mabill.Domain.Entities.Journals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mabill.Domain.Entities.Organizations
{
    public class Organization : Auditable
    {
        public Organization()
        {
            Journals = new List<Journal>();
        }

        public virtual ICollection<Journal> Journals { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }
        public Admin Owner { get; set; }
    }
}
