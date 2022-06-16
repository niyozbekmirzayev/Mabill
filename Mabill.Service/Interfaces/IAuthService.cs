using Mabill.Domain.Entities.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mabill.Service.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(Admin admin);
    }
}
