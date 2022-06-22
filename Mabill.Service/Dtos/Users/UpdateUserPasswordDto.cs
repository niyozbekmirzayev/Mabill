using System.ComponentModel.DataAnnotations;

namespace Mabill.Service.Dtos.Users
{
    public class UpdateUserPasswordDto
    {
        [Required]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
