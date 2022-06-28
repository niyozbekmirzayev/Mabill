using System.ComponentModel.DataAnnotations;

namespace Mabill.Service.Dtos.Organizations
{
    public class CreateOrganizationDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
