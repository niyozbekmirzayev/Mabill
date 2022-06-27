using Mabill.Domain.Base;
using Mabill.Domain.Entities.Users;
using Mabill.Domain.Enums;
using Mabill.Service.Dtos.Users;
using Mabill.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mabill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<BaseResponse<User>>> Create([FromForm] CreateUserDto user)
        {
            Console.WriteLine("---> Creating user....");
            var result = await userService.CreateAsync(user);

            // Identification of error 
            if (result.Error is not null)
            {
                if (result.Error.Code == 404) return NotFound(result);
                else if (result.Error.Code == 400) return BadRequest(result);
                else if (result.Error.Code == 409) return Conflict(result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<BaseResponse<User>>> GetUserById(Guid id)
        {
            Console.WriteLine("---> Getting user....");
            var result = await userService.GetAsync(p => p.Id == id && p.Status != ObjectStatus.Deleted);

            // Identification of error 
            if (result.Error is not null)
            {
                if (result.Error.Code == 404) return NotFound(result);
                else if (result.Error.Code == 400) return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet]
        public ActionResult<BaseResponse<IEnumerable<User>>> GetAllActiveUsers()
        {
            Console.WriteLine("---> Getting users....");
            var result = userService.GetAll(x => x.Status != ObjectStatus.Deleted);

            return Ok(result);
        }

        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<BaseResponse<bool>>> DeleteProfile(DeleteUserProfileDto user)
        {
            Console.WriteLine("---> Deleteing user....");
            var result = await userService.DeleteAsync(user);

            // Identification of error 
            if (result.Error is not null)
            {
                if (result.Error.Code == 404) return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPatch]
        [Authorize]
        public async Task<ActionResult<BaseResponse<User>>> UpdateProfile(UpdateUserProfileDto user)
        {
            Console.WriteLine("---> Updating user profile....");
            var result = await userService.UpdateProfileAsync(user);

            // Identification of error 
            if (result.Error is not null)
            {
                if (result.Error.Code == 404) return NotFound(result);
                if (result.Error.Code == 400) return BadRequest(result);
                if (result.Error.Code == 409) return Conflict(result);
            }

            return Ok(result);
        }


        [HttpPatch]
        [Authorize]
        public async Task<ActionResult<BaseResponse<User>>> UpdatePassword(UpdateUserPasswordDto user)
        {
            Console.WriteLine("---> Updating user password....");
            var result = await userService.UpdatePasswordAsync(user);

            // Identification of error 
            if (result.Error is not null)
            {
                if (result.Error.Code == 404) return NotFound(result);
                if (result.Error.Code == 400) return BadRequest(result);
                if (result.Error.Code == 409) return Conflict(result);
            }

            return Ok(result);
        }
    }
}
