using Mabill.API.Helpers;
using Mabill.Data.IRepositories;
using Mabill.Domain.Base;
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
        private WebHelperFunctions webHelperFunctions;
        private readonly IAuthService authService;
        private readonly IUserRepository userRepository;
        private IConfiguration config;

        public AuthController(IAuthService authService, IUserRepository userRepository, IConfiguration config)
        {
            this.authService = authService;
            this.userRepository = userRepository;
            this.config = config;
            webHelperFunctions = new WebHelperFunctions();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> CreateToken([FromBody] LoginDto loginParams)
        {
            var response = new BaseResponse<TokenInfoDto>();
            var user = await userRepository.GetAsync(user => user.Username == loginParams.Username.Trim().ToLower() &&
                                                       user.Password == loginParams.Password.EncodeInSha256() &&
                                                       user.Status != ObjectStatus.Deleted);

            if (user is null)
            {
                response.Error = new BaseError(400, "Invalid username or password");
                return webHelperFunctions.SentResultWithStatusCode(response);
            }

            string token = authService.GenerateToken(user);

            var tokenInofo = new TokenInfoDto
            {
                Token = token,
                Expires = DateTime.Now.AddMinutes(double.Parse(config.GetSection("JWT:Expire").Value))
            };

            Console.WriteLine($"{token} givent to user with the id of {user.Id}");
            response.Data = tokenInofo;

            return webHelperFunctions.SentResultWithStatusCode(response);
        }
    }
}
