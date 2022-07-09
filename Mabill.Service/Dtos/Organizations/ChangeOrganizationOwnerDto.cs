using System;
using System.ComponentModel.DataAnnotations;

namespace Mabill.Service.Dtos.Organizations
{
    public class ChangeOrganizationOwnerDto
    {
        [Required]
        public string OrganizationPassword { get; set; }
        [Required]
        public Guid NewOwnerId { get; set; }
    }
}
