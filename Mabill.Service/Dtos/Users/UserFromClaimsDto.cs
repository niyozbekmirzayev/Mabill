using Mabill.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        [JsonConverter(typeof(StringEnumConverter))]
        public StaffRole Role { get; set; }
    }
}
