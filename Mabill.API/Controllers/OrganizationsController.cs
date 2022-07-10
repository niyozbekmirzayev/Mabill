using Mabill.API.Helpers;
using Mabill.Domain.Enums;
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
        private WebHelperFunctions webHelperFunctions;
        public OrganizationsController(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
            webHelperFunctions = new WebHelperFunctions();
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateOrganizationDto organization)
        {
            Console.WriteLine("---> Creating organization....");
            var result = await organizationService.CreateAsync(organization);

            return webHelperFunctions.SentResultWithStatusCode(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(string organizationName)
        {
            Console.WriteLine("---> Getting organization....");
            var result = await organizationService.GetAsync(o => o.Name.Trim().ToLower() == organizationName.Trim().ToLower());

            return webHelperFunctions.SentResultWithStatusCode(result);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete([FromQuery] DeleteOrganizationDto deleteOrganizationDto)
        {
            Console.WriteLine("---> Deleting organization....");
            var result = await organizationService.DeleteAsync(deleteOrganizationDto);

            return webHelperFunctions.SentResultWithStatusCode(result);
        }

        [HttpGet]
        public IActionResult GetAllActiveOrganizations()
        {
            Console.WriteLine("---> Getting organization....");
            var result = organizationService.GetAll(x => x.Status != ObjectStatus.Deleted);

            return webHelperFunctions.SentResultWithStatusCode(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> ChangeOwner([FromQuery] ChangeOrganizationOwnerDto changeOrganizationOwnerDto)
        {
            Console.WriteLine("---> Changing owner....");
            var result = await organizationService.ChangeOwner(changeOrganizationOwnerDto);

            return webHelperFunctions.SentResultWithStatusCode(result);
        }
    }
}

