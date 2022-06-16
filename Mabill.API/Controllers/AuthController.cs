using Mabill.Data.IRepositories;
using Mabill.Domain.Enums;
using Mabill.Service.Dtos.Auth;
using Mabill.Service.Extensions;
using Mabill.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mabill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService authService;
        private readonly IAdminRepository adminRepository;
        public AuthController(IAuthService authService, IAdminRepository adminRepository)
        {
            this.authService = authService;
            this.adminRepository = adminRepository;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> CreateToken([FromBody] LoginDto loginParams)
        {
            var user = await adminRepository.GetAsync(admin => admin.Username == loginParams.Username &&
                                                       admin.Password == loginParams.Password.EncodeInSha256() &&
                                                       admin.Status != ObjectStatus.Deleted);

            if (user is null) return NotFound("Login or password did not match");

            string token = authService.GenerateToken(user);

            return Ok(token);
        }
    }
}
