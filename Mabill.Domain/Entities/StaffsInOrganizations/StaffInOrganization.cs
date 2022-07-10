using Mabill.Domain.Base;
using Mabill.Domain.Entities.Organizations;
using Mabill.Domain.Entities.Users;
using Mabill.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mabill.Domain.Entities.StaffsInOrganizations
{
    public class StaffInOrganization : Auditable
    {
        public StaffInOrganization(Guid userId, Guid organizationId, StaffRole role)
        {
            UserId = userId;
            OrganizationId = organizationId;
            Role = role;
        }

        [NotMapped]
        public decimal SumOfGivenLoans { get; set; }

        [JsonIgnore]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Column(TypeName = "varchar(24)")]
        [JsonConverter(typeof(StringEnumConverter))]
        public StaffRole Role { get; set; }

        [JsonIgnore]
        public Guid OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        public Organization Organization { get; set; }
    }
}
