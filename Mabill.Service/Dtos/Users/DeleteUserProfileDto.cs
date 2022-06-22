using System.ComponentModel.DataAnnotations;

namespace Mabill.Service.Dtos.Users
{
    public class DeleteUserProfileDto
    {
        [Required]
        public string Password { get; set; }
    }
}
