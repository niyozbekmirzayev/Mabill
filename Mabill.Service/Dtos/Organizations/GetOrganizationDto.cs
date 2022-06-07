using Mabill.Domain.Entities.Admins;
using Mabill.Domain.Entities.Journals;
using Mabill.Service.Dtos.Base;
using System.Collections.Generic;

namespace Mabill.Service.Dtos.Organizations
{
    public class GetOrganizationDto : AuditableDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal SumOfGivenLoans { get; set; }
        public ICollection<Admin> Admins { get; set; }
        public ICollection<Journal> Journals { get; set; }
        public Admin Owner { get; set; }
    }
}
