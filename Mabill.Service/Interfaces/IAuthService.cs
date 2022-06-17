using Mabill.Domain.Entities.Staffs;

namespace Mabill.Service.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(Staff staff);
    }
}
