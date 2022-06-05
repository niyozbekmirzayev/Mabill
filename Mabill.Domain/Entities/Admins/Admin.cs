using Mabill.Domain.Base;
using Mabill.Domain.Enums;

namespace Mabill.Domain.Entities.Admins
{
    public class Admin : Person
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public AdminRoles Role { get; set; }
    }
}
