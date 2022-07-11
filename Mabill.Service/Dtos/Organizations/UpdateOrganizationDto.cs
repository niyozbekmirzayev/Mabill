
using System;

namespace Mabill.Service.Dtos.Organizations
{
    public class UpdateOrganizationDto
    {
        public Guid Id { get; set; }
        public string NewName { get; set; }
        public string NewDescription { get; set; }
    }
}
