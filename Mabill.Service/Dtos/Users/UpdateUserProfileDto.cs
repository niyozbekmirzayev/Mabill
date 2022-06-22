using System;

namespace Mabill.Service.Dtos.Users
{
    public class UpdateUserProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime? BrithDate { get; set; }
    }
}
