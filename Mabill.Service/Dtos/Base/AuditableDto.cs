using Mabill.Domain.Enums;
using System;

namespace Mabill.Service.Dtos.Base
{
    public class AuditableDto : BaseDto
    {
        ObjectStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? LastModificatedDate { get; set; }
    }
}
