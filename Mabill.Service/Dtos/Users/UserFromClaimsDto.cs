using Mabill.Domain.Enums;
using System;

namespace Mabill.Service.Dtos.Users
{
    public class UserFromClaimsDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public StaffRole Role { get; set; }
    }
}
