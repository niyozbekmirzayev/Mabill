using Mabill.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Mabill.Service.Dtos.Base
{
    public class AuditableDto : BaseDto
    {
        [JsonConverter(typeof(StringEnumConverter))]
        ObjectStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTime? LastModificatedDate { get; set; }
    }
}
