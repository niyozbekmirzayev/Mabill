using System.ComponentModel.DataAnnotations;

namespace Mabill.Domain.Base
{
    public class Person : Auditable
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
