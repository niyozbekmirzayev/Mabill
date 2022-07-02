using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mabill.Service.Dtos.Organizations
{
    public class DeleteOrganizationDto
    {
        [Required]
        public string Password { get; set; }
    }
}
