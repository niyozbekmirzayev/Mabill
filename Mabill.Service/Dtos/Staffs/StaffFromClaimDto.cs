using Mabill.Domain.Enums;
using System;

namespace Mabill.Service.Dtos.Staffs
{
    public class StaffFromClaimsDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public StaffRole Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
