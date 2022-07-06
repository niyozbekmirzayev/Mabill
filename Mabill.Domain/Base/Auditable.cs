using Mabill.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mabill.Domain.Base
{
    public class Auditable : BaseEntity
    {
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public ObjectStatus Status { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; } = null;

        public DateTime? DeletedDate { get; set; } = null;
        public Guid? DeletedBy { get; set; } = null;

        public DateTime? LastModificatedDate { get; set; } = null;
        public Guid? ModifiedBy { get; set; } = null;

        public void Create(Guid? creatorId = null)
        {
            Status = ObjectStatus.Created;
            CreatedDate = DateTime.Now;
            CreatedBy = creatorId;
        }

        public void Delete(Guid? deletorId = null)
        {
            Status = ObjectStatus.Deleted;
            DeletedDate = DateTime.Now;
            DeletedBy = deletorId;
        }

        public void Modify(Guid? modifierId = null)
        {
            Status = ObjectStatus.Modified;
            LastModificatedDate = DateTime.Now;
            ModifiedBy = modifierId;
        }
    }
}
