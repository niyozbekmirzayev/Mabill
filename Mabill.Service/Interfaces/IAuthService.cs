using Mabill.Domain.Entities.Users;

namespace Mabill.Service.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(User user);
    }
}
