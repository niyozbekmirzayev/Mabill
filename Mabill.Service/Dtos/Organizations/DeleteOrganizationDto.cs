using System;
using System.ComponentModel.DataAnnotations;

namespace Mabill.Service.Dtos.Organizations
{
    public class DeleteOrganizationDto
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
