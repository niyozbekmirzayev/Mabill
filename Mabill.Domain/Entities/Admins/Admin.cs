using Mabill.Domain.Base;
using Mabill.Domain.Entities.Organizations;
using Mabill.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mabill.Domain.Entities.Admins
{
    public class Admin : Person
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public AdminRoles Role { get; set; }
        public decimal SumOfGivenLoans { get; set; }
        [ForeignKey(nameof(Organization))]
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
