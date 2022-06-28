using Mabill.Data.IRepositories;
using Mabill.Domain.Enums;
using Mabill.Service.Dtos.Auth;
using Mabill.Service.Extensions;
using Mabill.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Mabill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService authService;
        private readonly IUserRepository userRepository;
        private IConfiguration config;

        public AuthController(IAuthService authService, IUserRepository userRepository, IConfiguration config)
        {
            this.authService = authService;
            this.userRepository = userRepository;
            this.config = config;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> CreateToken([FromBody] LoginDto loginParams)
        {
            var user = await userRepository.GetAsync(user => user.Username == loginParams.Username.ToLower() &&
                                                       user.Password == loginParams.Password.EncodeInSha256() &&
                                                       user.Status != ObjectStatus.Deleted);

            if (user is null) return NotFound("Login or password did not match");

            string token = authService.GenerateToken(user);

            var tokenInofo = new TokenInfoDto
            {
                Token = token,
                Expires = DateTime.Now.AddMinutes(double.Parse(config.GetSection("JWT:Expire").Value))
            };

            Console.WriteLine($"{token} givent to user with the id of {user.Id}");
            return Ok(tokenInofo);
        }
    }
}
