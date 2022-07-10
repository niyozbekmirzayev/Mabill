using System;
using System.ComponentModel.DataAnnotations;

namespace Mabill.Service.Dtos.Organizations
{
    public class ChangeOrganizationOwnerDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Guid NewOwnerId { get; set; }
    }
}
