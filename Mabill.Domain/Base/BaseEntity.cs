using System;
using System.ComponentModel.DataAnnotations;

namespace Mabill.Domain.Base
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
