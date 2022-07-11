
using System;

namespace Mabill.Service.Dtos.Organizations
{
    public class UpdateOrganizationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
