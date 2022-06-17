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
        private readonly IStaffRepository staffRepository;
        public AuthController(IAuthService authService, IStaffRepository staffRepository)
        {
            this.authService = authService;
            this.staffRepository = staffRepository;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> CreateToken([FromBody] LoginDto loginParams)
        {
            var staff = await staffRepository.GetAsync(staff => staff.Username == loginParams.Username &&
                                                       staff.Password == loginParams.Password.EncodeInSha256() &&
                                                       staff.Status != ObjectStatus.Deleted);

            if (staff is null) return NotFound("Login or password did not match");

            string token = authService.GenerateToken(staff);

            return Ok(token);
        }
    }
}
