using Mabill.Domain.Enums;
using System;

namespace Mabill.Domain.Base
{
    public class Auditable : BaseEntity
    {
        ObjectStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? DeletedDate { get; set; } = null;
        public DateTime? LastModificatedDate { get; set; } = null;

        public void Create()
        {
            Status = ObjectStatus.Created;
            CreatedDate = DateTime.Now;
        }

        public void Delete()
        {
            Status = ObjectStatus.Deleted;
            DeletedDate = DateTime.Now;
        }

        public void Modify()
        {
            Status = ObjectStatus.Modified;
            LastModificatedDate = DateTime.Now;
        }
    }
}
