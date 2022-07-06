using System.ComponentModel.DataAnnotations;

namespace Mabill.Service.Dtos.Organizations
{
    public class CreateOrganizationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public string Description { get; set; }
    }
}
