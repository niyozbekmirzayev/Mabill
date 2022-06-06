using Mabill.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mabill.Domain.Base
{
    public class Auditable : BaseEntity
    {
        [Required]
        ObjectStatus Status { get; set; }
        [Required]
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
