using Mabill.Domain.Base;
using Mabill.Domain.Entities.Organizations;
using Mabill.Service.Dtos.Organizations;
using Mabill.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Mabill.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrganizationsController : Controller
    {
        private readonly IOrganizationService organizationService;
        public OrganizationsController(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BaseResponse<Organization>>> Create([FromBody] CreateOrganizationDto organization)
        {
            Console.WriteLine("---> Creating organization....");
            var result = await organizationService.CreateAsync(organization);

            // Identification of error 
            if (result.Error is not null)
            {
                if (result.Error.Code == 404) return NotFound(result);
                else if (result.Error.Code == 400) return BadRequest(result);
                else if (result.Error.Code == 409) return Conflict(result);
            }

            return Ok(result);
        }
    }
}
