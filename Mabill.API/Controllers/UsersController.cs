using Mabill.API.Helpers;
using Mabill.Domain.Enums;
using Mabill.Service.Dtos.Users;
using Mabill.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Mabill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private IUserService userService;
        private WebHelperFunctions webHelperFunctions;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
            webHelperFunctions = new WebHelperFunctions();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUserDto user)
        {
            Console.WriteLine("---> Creating user....");
            var result = await userService.CreateAsync(user);

            return webHelperFunctions.SentResultWithStatusCode(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            Console.WriteLine("---> Getting user....");
            var result = await userService.GetAsync(p => p.Id == id && p.Status != ObjectStatus.Deleted);

            return webHelperFunctions.SentResultWithStatusCode(result);
        }

        [HttpGet]
        public IActionResult GetAllActiveUsers()
        {
            Console.WriteLine("---> Getting users....");
            var result = userService.GetAll(x => x.Status != ObjectStatus.Deleted);

            return webHelperFunctions.SentResultWithStatusCode(result);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteProfile(DeleteUserProfileDto user)
        {
            Console.WriteLine("---> Deleteing user....");
            var result = await userService.DeleteAsync(user);

            return webHelperFunctions.SentResultWithStatusCode(result);
        }

        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> UpdateProfile(UpdateUserProfileDto user)
        {
            Console.WriteLine("---> Updating user profile....");
            var result = await userService.UpdateProfileAsync(user);

            return webHelperFunctions.SentResultWithStatusCode(result);
        }


        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> UpdatePassword(UpdateUserPasswordDto user)
        {
            Console.WriteLine("---> Updating user password....");
            var result = await userService.UpdatePasswordAsync(user);

            return webHelperFunctions.SentResultWithStatusCode(result);
        }
    }
}
