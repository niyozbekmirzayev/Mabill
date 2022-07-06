using System.ComponentModel.DataAnnotations;

namespace Mabill.Service.Dtos.Organizations
{
    public class DeleteOrganizationDto
    {
        [Required]
        public string OrganizationPassword { get; set; }
    }
}
